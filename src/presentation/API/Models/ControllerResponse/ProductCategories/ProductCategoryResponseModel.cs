using ApplicationLayer.Requests.ProductCategories.Queries;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Models.ControllerResponse.ProductCategories
{
	public static class ProductCategoryResponseModel
	{
		public static ProductCategoriesGetResponse GetResponseModel(this ProductCategoriesGetResponse result, List<HateoasResponse>? links)
		{
			foreach (var cat in result.Categories)
			{
				var link = links?.FirstOrDefault(x => x.ActionName == "getCategories");

				if (link is null)
				{
					continue;
				}

				var curl = new HateoasResponseBody(link.Curl!.Href, link.Curl!.Rel, link.Curl!.Method);

				curl.ReplaceInHref("{id}", $"{cat.Id}");

				cat.Links.Add(new() { Curl = new(curl.Href, curl.Rel, curl.Method), ActionName = link.ActionName });
			}

			links?.First(x => x.ActionName == "getProductsByCategory").ReplaceInLink("{catId}", $"{result.CategoryId}");

			links?.First(x => x.ActionName == "self").ReplaceInLink("{id}", $"{result.CategoryId}");

			result.Links = links!;

			return result;
		}
	}
}
