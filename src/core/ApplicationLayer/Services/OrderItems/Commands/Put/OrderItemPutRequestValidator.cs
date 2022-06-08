namespace ApplicationLayer.Services.OrderItems.Commands.Put
{
    using FluentValidation;

    public class OrderItemPutRequestValidator : AbstractValidator<OrderItemPutRequest>
    {
        public OrderItemPutRequestValidator()
        {
            RuleFor(req => req.OrderCode)
                 .NotNull()
                 .WithMessage("Order code cannot be empty or default value");

            RuleFor(req => req.UserId)
                 .NotNull()
                 .WithMessage("User id cannot be empty or default value");

            RuleFor(req => req.ProductCode)
                .NotEmpty()
                .WithMessage("ProductCode cannot be empty or default value");
        }
    }
}
