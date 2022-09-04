namespace PersistanceLayer.Contracts.Models.Orders
{
	public class OrderItemModel
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Count { get; set; }
		public string ProductCode { get; set; } = string.Empty;
	}
}
