namespace DomainLayer.Entities.Product
{
    public class ProductCategoryEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? ParentProductCategoryId { get; set; }
        public ProductCategoryEntity? ParentProductCategory { get; set; } = new();
        public IEnumerable<ProductEntity>? Products { get; set; }
        public IEnumerable<ProductCategoryRelationEntity>? ProductCategoryRelations { get; set; }
    }
}
