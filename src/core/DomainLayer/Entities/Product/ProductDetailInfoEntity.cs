namespace DomainLayer.Entities.Product
{
    using DomainLayer.Entities.Product.Localization;

    public class ProductDetailInfoEntity : AuditableEntity
    {
        public int ProductDetailId { get; set; }
        public ProductDetailEntity ProductDetail { get; set; } = new();
        public string DetailedDescription { get; set; } = string.Empty;
        public string Parameters { get; set; } = string.Empty;
        public IEnumerable<ProductDetailInfoLocalizedEntity>? Localizations { get; set; }
    }
}
