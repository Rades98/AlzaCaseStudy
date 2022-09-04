using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
using FluentValidation;

namespace ApplicationLayer.Requests.ProductDetails.Queries
{
	/// <summary>
	/// Shared validator for Get based requests
	/// </summary>
	public class ProductDetailGetValidator : AbstractValidator<ProductDetailGetRequest>
	{
		public ProductDetailGetValidator()
		{
			RuleFor(product => product.ProductCode)
				 .NotNull()
				 .WithMessage("Product code is not set");

			RuleFor(product => product.ProductCode)
				.NotEmpty()
				.WithMessage("Product code cannot be empty or default value");
		}
	}
}
