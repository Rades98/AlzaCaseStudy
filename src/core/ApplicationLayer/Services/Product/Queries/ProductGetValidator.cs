namespace ApplicationLayer.Services.Product.Queries
{
    using FluentValidation;
    using Requests;

    public class ProductGetValidator : AbstractValidator<ProductGetRequest>
    {
        public ProductGetValidator()
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
