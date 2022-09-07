using ApplicationLayer.Dtos;

namespace ApplicationLayer.Requests.Orders.Queries
{
	public class OrdersGetResponse : RestDtoBase
	{
		public string OrderCode { get; set; } = string.Empty;
		public List<OrderItemDto> OrderItems { get; set; } = new();
		public decimal Total { get; set; }
		public int OrderStatus { get; set; }
	}
}
