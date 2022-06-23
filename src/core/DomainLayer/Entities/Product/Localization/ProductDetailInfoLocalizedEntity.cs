namespace DomainLayer.Entities.Product.Localization
{
	public class ProductDetailInfoLocalizedEntity : AuditableLocalizableEntity
	{
		public string DetailedDescription { get; set; } = string.Empty;
		public string Parameters { get; set; } = string.Empty;
		public int ProductDetailInfoId { get; set; }
		public ProductDetailInfoEntity ProductDetailInfo { get; set; } = new();
	}
}
