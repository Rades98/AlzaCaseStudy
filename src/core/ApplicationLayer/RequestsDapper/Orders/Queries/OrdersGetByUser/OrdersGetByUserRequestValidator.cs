using FluentValidation;

namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser
{
	public class OrdersGetByUserRequestValidator : AbstractValidator<OrdersGetByUserRequest>
	{
		public OrdersGetByUserRequestValidator()
		{
			RuleFor(req => req.UserId)
				.NotEmpty()
				.WithMessage("User id cannot be empty or default value");
		}
	}
}
