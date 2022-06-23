namespace ApplicationLayer.Requests.Users.Commands.Login
{
	using Exceptions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using Utils.PasswordHashing;

	public class UserLoginRequest : IRequest<UserLoginResponse>
	{
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public byte[] Token { get; set; } = new byte[128];

		public class Handler : IRequestHandler<UserLoginRequest, UserLoginResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
			{
				var user = await _dbContext.Users
					.Include(x => x.Roles)
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

				if (user == null)
				{
					throw new CRUDException(ExceptionTypeEnum.NotFound, "User not found");
				}

				if (!PasswordHashing.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
				{
					throw new CRUDException(ExceptionTypeEnum.Unauthorized, "Wrong password");
				}

				var roles = user.Roles?.Select(role => role.Name).ToList();

				return new UserLoginResponse()
				{
					UserName = user.UserName,
					Token = PasswordHashing.CreateToken(user.Id, request.Token, roles!),
					Roles = roles ?? new()
				};
			}
		}
	}
}
