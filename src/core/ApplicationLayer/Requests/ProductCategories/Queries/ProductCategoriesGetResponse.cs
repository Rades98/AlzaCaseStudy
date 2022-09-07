using ApplicationLayer.Dtos;

namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	public class ProductCategoriesGetResponse : RestDtoBase
	{
		public int CategoryId { get; set; }
		public List<ProductCategoryDto> Categories { get; set; } = new();
	}
}
