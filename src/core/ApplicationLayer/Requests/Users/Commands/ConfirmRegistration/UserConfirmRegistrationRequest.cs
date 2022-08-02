namespace ApplicationLayer.Requests.Users.Commands.ConfirmRegistration
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class UserConfirmRegistrationRequest : IRequest<UserConfirmRegistrationResponse>
	{
		public string Code { get; set; } = string.Empty;

		public class Handler : IRequestHandler<UserConfirmRegistrationRequest, UserConfirmRegistrationResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => (_dbContext) = (dbContext);

			public async Task<UserConfirmRegistrationResponse> Handle(UserConfirmRegistrationRequest request, CancellationToken cancellationToken)
			{
				var registration = await _dbContext.UserRegistrations
					.AsNoTracking()
					.FirstOrDefaultAsync(r => r.Code == request.Code && r.LinkActiveTill >= DateTime.Now, cancellationToken);

				if (registration is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Code not found or is invalid");
				}

				var user = await _dbContext.Users
					.AsNoTracking()
					.Include(u => u.Registration)
					.FirstOrDefaultAsync(u => u.RegistrationId == registration.Id && !u.IsActive, cancellationToken);

				if (user is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "No user for this registration have been found");
				}

				user.IsActive = true;
				user.Registration!.LinkActiveTill = DateTime.Now;

				_dbContext.Users.Update(user);

				await _dbContext.SaveChangesAsync(cancellationToken);

				return new() { Success = true };
			}
		}
	}
}
