using ApplicationLayer.Dtos;
using ApplicationLayer.Requests.ProductDetails.Queries;

namespace API.Models.ProductDetails
{
	public class ProductDetailsGet : RestDtoBase
	{
		public IList<ProductDetailGetResponse> Products { get; set; } = new List<ProductDetailGetResponse>();
	}
}
