using ApplicationLayer.Dtos;
using ApplicationLayer.Interfaces;
using DomainLayer.Entities.Product;

namespace ApplicationLayer.Requests.ProductDetails.Queries
{
	/// <summary>
	/// Shared response for Get based requests
	/// </summary>
	public class ProductDetailGetResponse : RestDtoBase, IRecord
	{
		public Uri? ImgUri { get; set; }
		public string? Name { get; set; }
		public decimal Price { get; set; }
		public string? Description { get; set; }
		public int Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Changed { get; set; }
		public DateTime? Deleted { get; set; }
		public string ProductCode { get; set; } = string.Empty;

		public ProductDetailGetResponse() { }

		//Used for retyping from entity to product response dto
		public static explicit operator ProductDetailGetResponse(ProductDetailEntity v)
		{
			return new ProductDetailGetResponse()
			{
				ImgUri = v.ImgUri,
				Name = v.Name,
				Price = v.Price,
				Changed = v.Changed,
				Created = v.Created,
				Deleted = v.Deleted,
				Description = v.Description,
				Id = v.Id,
				ProductCode = v.ProductCode,
			};
		}
	}
}
