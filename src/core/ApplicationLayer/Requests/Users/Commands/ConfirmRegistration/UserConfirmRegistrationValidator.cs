using FluentValidation;

namespace ApplicationLayer.Requests.Users.Commands.ConfirmRegistration
{
	public class UserConfirmRegistrationValidator : AbstractValidator<UserConfirmRegistrationRequest>
	{
		public UserConfirmRegistrationValidator()
		{
			RuleFor(con => con.Code)
				.NotNull().WithMessage("Code cannot be null");
		}
	}
}
