using ApplicationLayer.Dtos;
using ApplicationLayer.Requests.ProductDetails.Queries;

namespace API.Models.ProductDetails
{
	public class ProductDetailSearch : RestDtoBase
	{
		public IList<ProductDetailGetResponse> Results { get; set; } = new List<ProductDetailGetResponse>();
	}
}
