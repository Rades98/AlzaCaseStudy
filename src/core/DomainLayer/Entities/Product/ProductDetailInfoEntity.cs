namespace DomainLayer.Entities.Product
{
    public class ProductDetailInfoEntity : AuditableEntity
    {
        public Guid ProductDetailId { get; set; }
        public ProductDetailEntity ProductDetail { get; set; } = new();
        public string DetailedDescription { get; set; } = string.Empty;
        public string Parameters { get; set; } = string.Empty;
    }
}
