using ApplicationLayer.Dtos;

namespace ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser
{
	public class OrdersGetResponse
	{
		public string OrderCode { get; set; } = string.Empty;
		public List<OrderItemDto> OrderItems { get; set; } = new();
		public decimal Total { get; set; }
		public string OrderStatus { get; set; } = string.Empty;
	}
}
