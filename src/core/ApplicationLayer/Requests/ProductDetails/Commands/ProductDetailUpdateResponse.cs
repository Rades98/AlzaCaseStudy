namespace ApplicationLayer.Requests.ProductDetails.Commands
{
	using Dtos;

	/// <summary>
	/// Response for <see cref="ProductDetailUpdateRequest"/>
	/// </summary>
	public class ProductDetailUpdateResponse : RestDtoBase
	{
		public bool Updated { get; set; } = false;
		public bool UpToDate { get; set; } = false;
		public string UpdateMessage { get; set; } = string.Empty;
	}
}
