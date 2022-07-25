namespace ApplicationLayer.Requests.Orders.Queries
{
	using ApplicationLayer.Dtos;

	public class OrdersGetResponse
	{
		public string OrderCode { get; set; } = string.Empty;
		public List<OrderItemDto> OrderItems { get; set; } = new();
		public decimal Total { get; set; }
		public int OrderStatus { get; set; }
	}
}
