using DomainLayer.Entities.Product.Localization;

namespace DomainLayer.Entities.Product
{
	public class ProductCategoryEntity : AuditableEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<ProductDetailEntity> ProductDetails { get; set; } = new();
		public ProductCategoryEntity? ParentProductCategory { get; set; }
		public int? ParentProductCategoryId { get; set; }
		public List<ProductCategoryEntity> ChildrenCategories { get; set; } = new();
		public List<ProductCategoryLocalizedEntity> Localizations { get; set; } = new();
	}
}
