using FluentValidation;

namespace ApplicationLayer.Requests.Orders.Commands.Put
{
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
