using FluentValidation;

namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser.Localized
{
	public class OrdersGetByUserRequestValidator : AbstractValidator<OrdersGetByUserRequest>
	{
		public OrdersGetByUserRequestValidator()
		{
			RuleFor(req => req.UserId)
				.NotEmpty()
				.WithMessage("User id cannot be empty or default value");

			RuleFor(req => req.LanguageCode)
				.NotEmpty()
				.WithMessage("Language code cannot be empty or default value");

			RuleFor(req => req.LanguageCode)
				.MinimumLength(2)
				.MaximumLength(2)
				.WithMessage("Language code must be 2 chars long");
		}
	}
}
