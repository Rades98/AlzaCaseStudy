namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser
{
	using FluentValidation;

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
