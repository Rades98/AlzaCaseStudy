using FluentValidation;

namespace ApplicationLayer.Requests.Users.Commands.Register
{
	public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
	{
		public UserRegisterValidator()
		{
			RuleFor(user => user.UserName)
				 .NotNull().WithMessage("User name is not set")
				 .MaximumLength(ApplicationSetting.ApplicationSetting.MAX_USERNAME_LENGHT).WithMessage("User name is too long")
				 .MinimumLength(ApplicationSetting.ApplicationSetting.MIN_USERNAME_LENGHT).WithMessage("User name is too short");

			RuleFor(user => user.Password)
				.NotNull()
				.MaximumLength(ApplicationSetting.ApplicationSetting.MAX_PW_LENGHT).WithMessage("Password is too long")
				.MinimumLength(ApplicationSetting.ApplicationSetting.MIN_PW_LENGHT).WithMessage("Password is too short")
				.Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
				.Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
				.Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
				.Matches(@"[-._!#%&,:;<>=@{}~\$\(\)\*\+\/\\\?\[\]\^\|]+").WithMessage("Password must contain special character");

			RuleFor(user => user.FirstName)
				 .NotNull().WithMessage("Firstname is not set")
				 .MaximumLength(ApplicationSetting.ApplicationSetting.MAX_FIRSTNAME_LENGHT).WithMessage("Firstname is too long")
				 .MinimumLength(ApplicationSetting.ApplicationSetting.MIN_FIRSTNAME_LENGHT).WithMessage("Firstname is too short");

			RuleFor(user => user.Surname)
				 .NotNull().WithMessage("Surname is not set")
				 .MaximumLength(ApplicationSetting.ApplicationSetting.MAX_SURNAME_LENGHT).WithMessage("Surname is too long")
				 .MinimumLength(ApplicationSetting.ApplicationSetting.MIN_SURNAME_LENGHT).WithMessage("Surname is too short");

			RuleFor(user => user.Email)
				.EmailAddress();
		}
	}
}
