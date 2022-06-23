namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser
{
	using ApplicationLayer.Dtos;

	public class OrdersGetResponse
	{
		public string OrderCode { get; set; } = string.Empty;
		public List<OrderItemDto> OrderItems { get; set; } = new();
		public decimal Total { get; set; }
		public string OrderStatus { get; set; } = string.Empty;
	}
}
