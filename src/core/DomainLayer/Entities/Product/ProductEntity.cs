namespace DomainLayer.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
        public Uri ImgUri { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = new();
        public Guid ProductCategoryId { get; set; } = new();
        public string ProductCode { get; set; } = string.Empty;
    }
}
