namespace DomainLayer.Entities.Product
{
    public class ProductCategoryEntity : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<ProductDetailEntity>? ProductDetails { get; set; }

        public ProductCategoryEntity? ParentProductCategory { get; set; }
        public Guid? ParentProductCategoryId { get; set; }
        public ICollection<ProductCategoryEntity>? ChildrenCategories { get; set; }
    }
}
