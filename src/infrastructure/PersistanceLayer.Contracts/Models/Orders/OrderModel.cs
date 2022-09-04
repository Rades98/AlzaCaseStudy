namespace PersistanceLayer.Contracts.Models.Orders
{
	public class OrderModel
	{
		public string OrderCode { get; set; } = string.Empty;
		public int OrderStatusId { get; set; }
		public decimal Total { get; set; }
		public List<OrderItemModel> OrderItems { get; set; } = new();
	}
}
