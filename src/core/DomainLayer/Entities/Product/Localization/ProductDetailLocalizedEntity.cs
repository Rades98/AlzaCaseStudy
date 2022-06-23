namespace DomainLayer.Entities.Product.Localization
{
	public class ProductDetailLocalizedEntity : AuditableLocalizableEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public Uri ImgUri { get; set; } = new("http://www.alza.cdn.cz/product");
		public int ProductDetailId { get; set; }
		public ProductDetailEntity ProductDetail { get; set; } = new();
	}
}
