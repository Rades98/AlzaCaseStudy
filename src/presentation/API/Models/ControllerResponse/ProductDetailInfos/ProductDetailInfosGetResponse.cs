using ApplicationLayer.Requests.ProductDetailInfos.Queries;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.ProductDetailInfos
{
	public static class ProductDetailInfosGetResponse
	{
		public static ProductDetailInfoGetResponse GetResponseModel(this ProductDetailInfoGetResponse model, List<HateoasResponse>? links, string? orderCode = null)
		{
			var self = links!.First(x => x.ActionName == "self");

			self!.ReplaceInLink("{code}", $"{model.ProductCode}");

			model.Links.Add(self);

			if (orderCode is not null)
			{
				if (model.InStock > 0)
				{
					var addToCartLink = links!.First(x => x.ActionName == "onAddToCart");
					var addToCartCurl = new HateoasResponseBody(addToCartLink.Curl!.Href, addToCartLink.Curl!.Rel, addToCartLink.Curl!.Method);

					addToCartCurl.ReplaceInHref("{orderCode}", orderCode, "{productCode}", model.ProductCode);

					model.Links.Add(new() { ActionName = addToCartLink.ActionName, Curl = addToCartCurl });
				}

				//Here should be controll if there is this article in order.. but not now 
				var removeFromCartLink = links!.First(x => x.ActionName == "onRemoveFromCart");
				var removeFromCartCurl = new HateoasResponseBody(removeFromCartLink.Curl!.Href, removeFromCartLink.Curl!.Rel, removeFromCartLink.Curl!.Method);

				removeFromCartCurl.ReplaceInHref("{orderCode}", orderCode, "{productCode}", model.ProductCode);

				model.Links.Add(new() { ActionName = removeFromCartLink.ActionName, Curl = removeFromCartCurl });
			}

			return model;
		}
	}
}
