namespace ApplicationLayer.Requests.Users.Queries.Login
{
	using System.Security.Claims;
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
			private readonly ClaimsPrincipal _user;

			public Handler(IDbContext dbContext, ClaimsPrincipal user) => (_dbContext, _user) = (dbContext, user);

			public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
			{
				var user = await _dbContext.Users
					.Include(x => x.Roles)
					.AsNoTracking()
					.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

				if (user == null || !user.IsActive)
				{
					throw new MediatorException(ExceptionType.NotFound, "User not found");
				}

				if (!PasswordHashing.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
				{
					throw new MediatorException(ExceptionType.Unauthorized, "Wrong password");
				}

				var roles = user.Roles?.Select(role => role.Name).ToList() ?? new List<string>();

				var claims = new List<Claim>();

				roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
				_user.AddIdentity(new ClaimsIdentity(claims));

				return new UserLoginResponse()
				{
					UserName = user.UserName,
					Token = PasswordHashing.CreateToken(user.Id, request.Token, roles!)
				};
			}
		}
	}
}
