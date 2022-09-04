using ApplicationLayer.Dtos;
using ApplicationLayer.Interfaces;
using PersistanceLayer.Contracts.Models.ProductDetailInfos;

namespace ApplicationLayer.Requests.ProductDetailInfos.Queries
{
	public class ProductDetailInfoGetResponse : RestDtoBase, IRecord
	{
		public int Id { get; set; }
		public string DetailedDescription { get; set; } = string.Empty;
		public string Parameters { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;

		public int Count { get; set; }

		public static explicit operator ProductDetailInfoGetResponse(ProductDetailInfoModel v)
		{
			return new ProductDetailInfoGetResponse()
			{
				Id = v.Id,
				DetailedDescription = v.DetailedDescription,
				Parameters = v.Parameters,
				ProductCode = v.ProductCode
			};
		}
	}
}
