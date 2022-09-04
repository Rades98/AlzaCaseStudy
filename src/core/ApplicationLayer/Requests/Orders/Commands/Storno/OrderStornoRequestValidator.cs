using FluentValidation;

namespace ApplicationLayer.Requests.Orders.Commands.Storno
{
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
