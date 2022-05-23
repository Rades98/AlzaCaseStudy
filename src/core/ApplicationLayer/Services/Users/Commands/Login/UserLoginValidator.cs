namespace ApplicationLayer.Services.Users.Commands.Login
{
    using FluentValidation;

    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        private const int MAX_USERNAME_LENGHT = 20;
        private const int MIN_USERNAME_LENGHT = 5;

        private const int MAX_PW_LENGHT = 40;
        private const int MIN_PW_LENGHT = 10;

        public UserLoginValidator()
        {
            RuleFor(user => user.UserName)
                 .NotNull()
                 .WithMessage("User name is not set");

            RuleFor(user => user.UserName)
                 .NotNull()
                 .MaximumLength(MAX_USERNAME_LENGHT)
                 .WithMessage("User name is too long");

            RuleFor(user => user.UserName)
                 .NotNull()
                 .MinimumLength(MIN_USERNAME_LENGHT)
                 .WithMessage("User name is too short");

            RuleFor(user => user.Password)
                 .NotNull()
                 .MaximumLength(MAX_PW_LENGHT)
                 .WithMessage("Password is too long");

            RuleFor(user => user.Password)
                 .NotNull()
                 .MinimumLength(MIN_PW_LENGHT)
                 .WithMessage("Password name is too short");
        }
    }
}
