using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.Users.Commands.Register
{
	public class UserRegisterRequest : IRequest<UserRegisterResponse>
	{
		public string FirstName { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public class Handler : IRequestHandler<UserRegisterRequest, UserRegisterResponse>
		{
			private readonly IUsersRepository _repo;

			public Handler(IUsersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<UserRegisterResponse> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
			{
				var user = await _repo.RegisterUserAsync(request.UserName, request.Email, request.FirstName, request.Surname, request.Password, cancellationToken);

				MailSender.MailSender.SendRegistrationEmail(request.Email, user.Registration!.Code, request.UserName);

				return new()
				{
					Code = user.Registration.Code,
					UserName = request.UserName,
				};
			}
		}
	}
}
