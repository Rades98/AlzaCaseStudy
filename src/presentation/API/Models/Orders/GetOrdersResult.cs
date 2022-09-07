using ApplicationLayer.Dtos;
using ApplicationLayer.Requests.Orders.Queries;

namespace API.Models.Orders
{
	public class GetOrdersResult : RestDtoBase
	{
		public IList<OrdersGetResponse> Orders { get; set; } = new List<OrdersGetResponse>();
	}
}
