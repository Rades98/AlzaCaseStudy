using API.Models.ProductDetails;
using ApplicationLayer.Requests.ProductDetails.Queries;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.ProductDetails
{
	public static class ProductDetailsGetResponse
	{
		public static ProductDetailsGet GetResponseModels(this IList<ProductDetailGetResponse> models, List<HateoasResponse> links, string? orderCode = null, int? pageSize = null, int? pageNum = null)
		{
			var result = new ProductDetailsGet();

			var self = links.FirstOrDefault(x => x.ActionName == "self");

			if(pageSize is not null && pageNum is not null)
			{
				self?.ReplaceInLink("{pageSize}", $"{pageSize}", "{pageNum}", $"{pageNum}");
			}

			if (self is not null)
			{
				result.Links.Add(self);
			}

			models.ToList().ForEach(model => model.GetResponseModel(links, orderCode));

			result.Products = models;

			return result;
		}

		public static ProductDetailGetResponse GetResponseModel(this ProductDetailGetResponse model, List<HateoasResponse>? links, string? orderCode = null)
		{
			var detailInfoLink = links!.First(x => x.ActionName == "productDetail");
			var detailInfoCurl = new HateoasResponseBody(detailInfoLink.Curl!.Href, detailInfoLink.Curl!.Rel, detailInfoLink.Curl!.Method);

			detailInfoCurl.ReplaceInHref("{code}", model.ProductCode);

			model.Links.Add(new() { ActionName = detailInfoLink.ActionName, Curl = detailInfoCurl });

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

			var updateDescriptionLink = links!.FirstOrDefault(x => x.ActionName == "updateDescription");

			if (updateDescriptionLink is not null)
			{
				var updateDescriptionCurl = new HateoasResponseBody(updateDescriptionLink.Curl!.Href, updateDescriptionLink.Curl!.Rel, updateDescriptionLink.Curl!.Method);

				updateDescriptionCurl.ReplaceInHref("{Id}", $"{model.Id}");

				model.Links.Add(new() { ActionName = updateDescriptionLink.ActionName, Curl = updateDescriptionCurl });
			}

			return model;
		}
	}
}
