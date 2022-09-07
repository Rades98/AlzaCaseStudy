using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Entities.Product.Localization;

namespace DomainLayer.Entities.Product
{
	public class ProductDetailEntity : AuditableEntity
	{
		public Uri ImgUri { get; set; } = new("http://www.alza.cdn.cz/product");
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string? Description { get; set; }
		public ProductCategoryEntity? ProductCategory { get; set; }
		public int ProductCategoryId { get; set; }
		public string ProductCode { get; set; } = string.Empty;
		public List<ProductEntity>? Products { get; set; }
		public ProductDetailInfoEntity? ProductDetailInfo { get; set; }
		public int? ProductDetailInfoId { get; set; }
		public List<ProductDetailLocalizedEntity>? Localizations { get; set; }
	}
}
