namespace ApplicationLayer.Services.Orders.Commands.Storno
{
    using FluentValidation;

    public class OrderStornoRequestValidator : AbstractValidator<OrderStornoRequest>
    {
        public OrderStornoRequestValidator()
        {
            RuleFor(req => req.UserId)
                .NotEmpty()
                .WithMessage("User id cannot be empty or default value");

            RuleFor(req => req.OrderCode)
                .NotEmpty()
                .WithMessage("Order code cannot be empty or default value");
        }
    }
}
