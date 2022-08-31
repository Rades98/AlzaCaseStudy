namespace ApplicationLayer.Requests.Users.Commands.ConfirmRegistration
{
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class UserConfirmRegistrationRequest : IRequest<UserConfirmRegistrationResponse>
	{
		public string Code { get; set; } = string.Empty;

		public class Handler : IRequestHandler<UserConfirmRegistrationRequest, UserConfirmRegistrationResponse>
		{
			private readonly IUsersRepository _repo;

			public Handler(IUsersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<UserConfirmRegistrationResponse> Handle(UserConfirmRegistrationRequest request, CancellationToken cancellationToken)
			{
				await _repo.ConfirmUserRegistrationAsync(request.Code, cancellationToken);

				return new() { Success = true };
			}
		}
	}
}
