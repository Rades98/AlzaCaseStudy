namespace ApplicationLayer.Requests.Users.Commands.Register
{
	using System.Security.Cryptography;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Interfaces;
	using ApplicationLayer.Utils.PasswordHashing;
	using DomainLayer.Entities.Users;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class UserRegisterRequest : IRequest<UserRegisterResponse>
	{
		public string FirstName { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public class Handler : IRequestHandler<UserRegisterRequest, UserRegisterResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => (_dbContext) = (dbContext);

			public async Task<UserRegisterResponse> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
			{
				var potencialSameName = await _dbContext.Users
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

				var potencialSameEmail = await _dbContext.Users
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

				if (potencialSameName is not null)
				{
					throw new MediatorException(ExceptionType.Error, "User with same name already exists");
				}

				if (potencialSameEmail is not null)
				{
					throw new MediatorException(ExceptionType.Error, "There is running registration for provided email");
				}

				MD5 md5 = MD5.Create();
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(request.FirstName + request.Surname + request.UserName + request.Email);
				byte[] hash = md5.ComputeHash(inputBytes);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hash.Length; i++)
				{
					sb.Append(hash[i].ToString("x2"));
				}

				string code = sb.ToString();

				PasswordHashing.CreatePasswordHash(request.Password, out byte[] pwHash, out byte[] pwSalt);

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
						Email = request.Email,
						UserName = request.UserName,
						Surname = request.Surname,
						Name = request.FirstName,
						IsActive = false,
						Created = DateTime.Now,
						PasswordHash = pwHash,
						PasswordSalt = pwSalt
					};

					_dbContext.Users.Add(newUser);
					await _dbContext.SaveChangesAsync(cancellationToken);

					MailSender.MailSender.SendRegistrationEmail(request.Email, code, request.UserName);

					transaction.Commit();

					return new()
					{
						Code = code,
						UserName = request.UserName,
					};
				}
				catch (Exception e)
				{
					transaction.Rollback();
					throw new MediatorException(ExceptionType.Error, "User registration failed", e);
				}
			}
		}
	}
}
