namespace DomainLayer.Entities.Product
{
    public class ProductEntity : AuditableEntity
    {
        public Guid ProductDetailId { get; set; }
        public ProductDetailEntity ProductDetail { get; set; } = new();
    }
}
