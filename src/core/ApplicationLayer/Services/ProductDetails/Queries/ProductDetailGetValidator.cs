namespace ApplicationLayer.Services.ProductDetails.Queries
{
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using FluentValidation;
    using Requests;

    /// <summary>
    /// Shared validator for Get based requests
    /// </summary>
    public class ProductDetailGetValidator : AbstractValidator<ProductDetailGetRequest>
    {
        public ProductDetailGetValidator()
        {
            RuleFor(product => product.Id)
                 .NotNull()
                 .WithMessage("Product id is not set");

            RuleFor(product => product.Id)
                .NotEmpty()
                .WithMessage("Product id cannot be empty or default value");
        }
    }
}
