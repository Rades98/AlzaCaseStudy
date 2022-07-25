namespace ApplicationLayer.Requests.ProductDetailInfos.Queries
{
	using ApplicationLayer.Dtos;
	using ApplicationLayer.Interfaces;
	using DomainLayer.Entities.Product;

	public class ProductDetailInfoGetResponse : RestDtoBase, IRecord
	{
		public int Id { get; set; }
		public string DetailedDescription { get; set; } = string.Empty;
		public string Parameters { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;

		public int Count { get; set; }

		public static explicit operator ProductDetailInfoGetResponse(ProductDetailInfoEntity v)
		{
			return new ProductDetailInfoGetResponse()
			{
				Id = v.Id,
				DetailedDescription = v.DetailedDescription,
				Parameters = v.Parameters,
				ProductCode = v.ProductDetail.ProductCode
			};
		}
	}
}
