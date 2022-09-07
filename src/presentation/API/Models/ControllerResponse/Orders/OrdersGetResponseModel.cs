using API.Models.Orders;
using ApplicationLayer.Requests.Orders.Queries;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.Orders
{
	public static class OrdersGetResponseModel
	{
		public static GetOrdersResult GetResponseModels(this IList<OrdersGetResponse> models, List<HateoasResponse> links, int? statusId = null)
		{
			var result = new GetOrdersResult();

			var self = links.First(x => x.ActionName == "self");

			if (statusId is not null)
			{
				self.ReplaceInLink("{statusId}", $"{statusId}");
			}

			result.Links.Add(self);

			models.ToList().ForEach(model =>
			{
				var link = links!.First(x => x.ActionName == "getProduct");

				model.OrderItems.ForEach(orderItem =>
				{
					var curl = new HateoasResponseBody(link.Curl!.Href, link.Curl!.Rel, link.Curl!.Method);
					curl.ReplaceInHref("{code}", orderItem.ProductCode);
					orderItem.Links.Add(new() { ActionName = link.ActionName, Curl = curl });
				});
			});

			result.Orders = models;

			return result;
		}
	}
}
