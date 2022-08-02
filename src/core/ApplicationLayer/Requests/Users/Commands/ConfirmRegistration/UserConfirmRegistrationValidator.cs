namespace ApplicationLayer.Requests.Users.Commands.ConfirmRegistration
{
	using FluentValidation;

	public class UserConfirmRegistrationValidator : AbstractValidator<UserConfirmRegistrationRequest>
	{
		public UserConfirmRegistrationValidator()
		{
			RuleFor(con => con.Code)
				.NotNull().WithMessage("Code cannot be null");
		}
	}
}
