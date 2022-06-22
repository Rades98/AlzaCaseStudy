namespace ApplicationLayer.Requests.ProductDetails.Commands
{
	using FluentValidation;

	/// <summary>
	/// validator for <see cref="ProductDetailUpdateRequest"/>
	/// </summary>
	internal class ProductDetailUpdateValidator : AbstractValidator<ProductDetailUpdateRequest>
	{
		private const int MAX_DESCRIPTION_LENGHT = 250;
		private const int MIN_DESCRIPTION_LENGHT = 40;

		public ProductDetailUpdateValidator()
		{
			RuleFor(product => product.Description)
				.MaximumLength(MAX_DESCRIPTION_LENGHT)
				.WithMessage($"Product description cannot be longer than {MAX_DESCRIPTION_LENGHT} chars");

			RuleFor(product => product.Description)
				.MinimumLength(MIN_DESCRIPTION_LENGHT)
				.WithSeverity(Severity.Warning)
				.WithMessage($"Product description shloud be at least {MIN_DESCRIPTION_LENGHT} chars long");

			RuleFor(product => product.Description)
				.NotEmpty()
				.WithMessage("Product description cannot be empty or default value");

			RuleFor(product => product.Id)
				.NotNull()
				.WithMessage("Product id is not set");

			RuleFor(product => product.Id)
				.NotEmpty()
				.WithMessage("Product id cannot be empty or default value");
		}
	}
}
