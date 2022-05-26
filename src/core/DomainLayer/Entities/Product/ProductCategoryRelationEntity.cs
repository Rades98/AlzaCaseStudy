namespace DomainLayer.Entities.Product
{
    public class ProductCategoryRelationEntity : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = new();
        public Guid ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } = new();
    }
}
