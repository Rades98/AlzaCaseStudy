using FluentValidation;

namespace ApplicationLayer.RequestsDapper.OrderItems.Commands.Delete
{
	internal class OrderItemDeleteRequestValidator : AbstractValidator<OrderItemDeleteRequest>
	{
		public OrderItemDeleteRequestValidator()
		{
			RuleFor(req => req.OrderCode)
				.NotNull()
				 .WithMessage("Order code cannot be empty or default value");

			RuleFor(req => req.ProductCode)
				.NotNull()
				 .WithMessage("Product code cannot be empty or default value");

			RuleFor(req => req.UserId)
			   .NotNull()
				.WithMessage("User Id cannot be empty or default value");
		}
	}
}
