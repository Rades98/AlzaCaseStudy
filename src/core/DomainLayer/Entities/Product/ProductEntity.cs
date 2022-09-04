namespace DomainLayer.Entities.Product
{
	public class ProductEntity : AuditableEntity
	{
		public int ProductDetailId { get; set; }
		public ProductDetailEntity? ProductDetail { get; set; }
	}
}
