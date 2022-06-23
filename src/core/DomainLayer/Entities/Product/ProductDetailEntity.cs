namespace DomainLayer.Entities.Product
{
    using DomainLayer.Entities.Product.Localization;

    public class ProductDetailEntity : AuditableEntity
    {
        public Uri ImgUri { get; set; } = new("http://www.alza.cdn.cz/product");
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = new();
        public int ProductCategoryId { get; set; } = new();
        public string ProductCode { get; set; } = string.Empty;
        public IEnumerable<ProductEntity>? Products { get; set; }
        public ProductDetailInfoEntity? ProductDetailInfo { get; set; }
        public int? ProductDetailInfoId { get; set; }
        public IEnumerable<ProductDetailLocalizedEntity>? Localizations { get; set; }
    }
}
