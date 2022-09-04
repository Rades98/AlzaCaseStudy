using System.Security.Claims;
using AppUtils.PasswordHashing;
using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.Users.Queries.Login
{
	public class UserLoginRequest : IRequest<UserLoginResponse>
	{
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public byte[] Token { get; set; } = new byte[128];

		public class Handler : IRequestHandler<UserLoginRequest, UserLoginResponse>
		{
			private readonly ClaimsPrincipal _user;

			private readonly IUsersRepository _repo;

			public Handler(IUsersRepository repo, ClaimsPrincipal user)
			{
				_repo = repo ?? throw new ArgumentNullException(nameof(repo));
				_user = user ?? throw new ArgumentNullException(nameof(user));
			}

			public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
			{
				var user = await _repo.LoginUserAsync(request.UserName, request.Password, cancellationToken);

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
