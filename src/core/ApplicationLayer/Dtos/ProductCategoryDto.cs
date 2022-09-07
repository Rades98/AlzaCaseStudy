using DomainLayer.Entities.Product;

namespace ApplicationLayer.Dtos
{
	public class ProductCategoryDto : RestDtoBase
	{
		public int Id { get; set; }
		public string CategoryName { get; set; } = string.Empty;

		public static explicit operator ProductCategoryDto(ProductCategoryEntity entity)
		{
			return new ProductCategoryDto()
			{
				Id = entity.Id,
				CategoryName = entity.Name,
			};
		}
	}
}
