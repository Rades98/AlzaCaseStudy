using FluentValidation;

namespace ApplicationLayer.Requests.Orders.Commands.ChangeStatus
{
	public class OrderChangeStatusRequestValidator : AbstractValidator<OrderChangeStatusRequest>
	{
		public OrderChangeStatusRequestValidator()
		{
			RuleFor(req => req.OrderCode)
				 .NotNull()
				 .WithMessage("Order code cannot be empty or default value");

			RuleFor(req => req.UserId)
				.NotEmpty()
				.WithMessage("User id cannot be empty or default value");

			RuleFor(req => req.StatusId)
				.NotEmpty()
				.WithMessage("Status id cannot be empty or default value");
		}
	}
}
