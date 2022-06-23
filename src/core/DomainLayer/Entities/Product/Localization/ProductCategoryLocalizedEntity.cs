namespace DomainLayer.Entities.Product.Localization
{
	public class ProductCategoryLocalizedEntity : AuditableLocalizableEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public int ProductCategoryId { get; set; }
		public ProductCategoryEntity ProductCategory { get; set; } = new();
	}
}
