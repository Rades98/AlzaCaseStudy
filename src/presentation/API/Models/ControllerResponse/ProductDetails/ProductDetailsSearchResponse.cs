using API.Models.ProductDetails;
using ApplicationLayer.Requests.ProductDetails.Queries;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.ProductDetails
{
	public static class ProductDetailsSearchResponse
	{
		public static ProductDetailSearch GetSearchResponseModels(this IList<ProductDetailGetResponse> models, string phrase, List<HateoasResponse>? links, string? orderCode)
		{
			var result = new ProductDetailSearch();
			foreach (var model in models)
			{
				var link = links!.First(x => x.ActionName == "getDetail");
				var curl = new HateoasResponseBody(link.Curl!.Href, link.Curl!.Rel, link.Curl!.Method);

				curl.ReplaceInHref("{id}", $"{model.Id}");

				model.Links.Add(new() { Curl = curl, ActionName = link.ActionName});

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
			}

			var self = links?.First(x => x.ActionName == "self");
			self?.ReplaceInLink("{phrase}", $"{phrase}");

			if(self is not null)
			{
				result.Links.Add(self);
			}

			result.Results = models;

			return result;
		}

		public static ProductDetailSearch GetSearchByCatIdResponseModels(this IList<ProductDetailGetResponse> models, int catId, List<HateoasResponse>? links, string? orderCode)
		{
			var result = new ProductDetailSearch();

			foreach (var model in models)
			{
				var link = links!.First(x => x.ActionName == "getDetail");
				var curl = new HateoasResponseBody(link.Curl!.Href, link.Curl!.Rel, link.Curl!.Method);

				curl.ReplaceInHref("{id}", $"{model.Id}");

				model.Links.Add(new() { Curl = curl, ActionName = link.ActionName });

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
			}

			links?.First(x => x.ActionName == "self").ReplaceInLink("{catId}", $"{catId}");

			result.Links = links!;

			result.Results = models;

			return result;
		}
	}
}
