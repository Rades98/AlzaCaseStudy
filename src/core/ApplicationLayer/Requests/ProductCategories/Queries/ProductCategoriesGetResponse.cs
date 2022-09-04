using ApplicationLayer.Dtos;

namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	public class ProductCategoriesGetResponse : RestDtoBase
	{
		public ProductCategoryDto CategoryTree { get; set; } = new();
	}
}
