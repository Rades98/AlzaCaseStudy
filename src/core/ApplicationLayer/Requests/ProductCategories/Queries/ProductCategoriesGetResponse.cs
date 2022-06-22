namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	using ApplicationLayer.Dtos;

	public class ProductCategoriesGetResponse : RestDtoBase
	{
		public ProductCategoryDto CategoryTree { get; set; } = new();
	}
}
