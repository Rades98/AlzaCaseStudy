namespace ApplicationLayer.Services.Orders.Commands.Put
{
    using FluentValidation;

    public class OrdersPutRequestValidator : AbstractValidator<OrdersPutRequest>
    {
        public OrdersPutRequestValidator()
        {
            RuleFor(req => req.UserId)
                .NotEmpty()
                .WithMessage("User id cannot be empty or default value");
        }
    }
}
