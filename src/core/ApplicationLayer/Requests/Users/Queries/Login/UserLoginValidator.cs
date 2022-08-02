namespace ApplicationLayer.Requests.Users.Queries.Login
{
	using FluentValidation;

	public class UserLoginValidator : AbstractValidator<UserLoginRequest>
	{
		public UserLoginValidator()
		{
			RuleFor(user => user.UserName)
				 .NotNull().WithMessage("User name is not set")
				 .MaximumLength(ApplicationSetting.ApplicationSetting.MAX_USERNAME_LENGHT).WithMessage("User name is too long")
				 .MinimumLength(ApplicationSetting.ApplicationSetting.MIN_USERNAME_LENGHT).WithMessage("User name is too short");


			RuleFor(user => user.Password)
				 .NotNull().WithMessage("Password is not set")
				 .MaximumLength(ApplicationSetting.ApplicationSetting.MAX_PW_LENGHT).WithMessage("Password is too long")
				 .MinimumLength(ApplicationSetting.ApplicationSetting.MIN_PW_LENGHT).WithMessage("Password is too short");
		}
	}
}
