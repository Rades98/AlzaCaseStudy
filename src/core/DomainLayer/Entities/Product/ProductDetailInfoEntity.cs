namespace DomainLayer.Entities.Product
{
    using DomainLayer.Entities.Product.Localization;

    public class ProductDetailInfoEntity : AuditableEntity
    {
        public int ProductDetailId { get; set; }
        public virtual ProductDetailEntity? ProductDetail { get; set; }
        public string DetailedDescription { get; set; } = string.Empty;
        public string Parameters { get; set; } = string.Empty;
        public virtual List<ProductDetailInfoLocalizedEntity>? Localizations { get; set; }
    }
}
