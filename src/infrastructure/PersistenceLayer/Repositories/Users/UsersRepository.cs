namespace PersistenceLayer.Repositories.Users
{
	using System.Security.Cryptography;
	using System.Text;
	using AppUtils.PasswordHashing;
	using CodeLists.Exceptions;
	using DomainLayer.Entities.Users;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;

	public class UsersRepository : IUsersRepository
	{
		private readonly IDbContext _dbContext;

		public UsersRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task ConfirmUserRegistrationAsync(string registrationCode, CancellationToken ct)
		{
			var registration = await _dbContext.UserRegistrations
					.AsNoTracking()
					.FirstOrDefaultAsync(r => r.Code == registrationCode && r.LinkActiveTill >= DateTime.Now, ct);

			if (registration is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Code not found or is invalid");
			}

			var user = await _dbContext.Users
				.AsNoTracking()
				.Include(u => u.Registration)
				.FirstOrDefaultAsync(u => u.RegistrationId == registration.Id && !u.IsActive, ct);

			if (user is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "No user for this registration have been found");
			}

			user.IsActive = true;
			user.Registration!.LinkActiveTill = DateTime.Now;

			_dbContext.Users.Update(user);

			await _dbContext.SaveChangesAsync(ct);
		}

		/// <inheritdoc/>
		public async Task<UserEntity> RegisterUserAsync(string userName, string email, string firstName, string surname, string password, CancellationToken ct)
		{
			var potencialSameName = await _dbContext.Users
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.UserName == userName, ct);

			var potencialSameEmail = await _dbContext.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(u => u.Email == email, ct);

			if (potencialSameName is not null)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "User with same name already exists");
			}

			if (potencialSameEmail is not null)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "There is running registration for provided email");
			}

			MD5 md5 = MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(firstName + surname + userName + email);
			byte[] hash = md5.ComputeHash(inputBytes);
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("x2"));
			}

			string code = sb.ToString();

			PasswordHashing.CreatePasswordHash(password, out byte[] pwHash, out byte[] pwSalt);

			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var newUser = new UserEntity()
				{
					Registration = new UserRegistrationEntity()
					{
						LinkActiveTill = DateTime.Now.AddDays(ApplicationSetting.ApplicationSetting.RegistrationActivationDelay),
						Code = code
					},
					Email = email,
					UserName = userName,
					Surname = surname,
					Name = firstName,
					IsActive = false,
					Created = DateTime.Now,
					PasswordHash = pwHash,
					PasswordSalt = pwSalt
				};

				_dbContext.Users.Add(newUser);
				await _dbContext.SaveChangesAsync(ct);



				transaction.Commit();

				return newUser;
			}
			catch (Exception e)
			{
				transaction.Rollback();
				throw new PersistanceLayerException(ExceptionType.Error, "User registration failed", e);
			}
		}

		/// <inheritdoc/>
		public async Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken ct)
		{
			var user = await _dbContext.Users
					.Include(x => x.Roles)
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.UserName == userName, ct);

			if (user == null || !user.IsActive)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "User not found");
			}

			if (!PasswordHashing.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
			{
				throw new PersistanceLayerException(ExceptionType.Unauthorized, "Wrong password");
			}

			return user;
		}
	}
}
