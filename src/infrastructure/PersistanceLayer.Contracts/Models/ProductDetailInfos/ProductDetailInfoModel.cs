namespace PersistanceLayer.Contracts.Models.ProductDetailInfos
{
	public class ProductDetailInfoModel
	{
		public int Id { get; set; }
		public int ProductDetailId { get; set; }
		public string DetailedDescription { get; set; } = string.Empty;
		public string Parameters { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
	}
}
