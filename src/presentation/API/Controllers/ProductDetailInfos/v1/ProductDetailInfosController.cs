using API.Constants;
using API.Controllers.OrderItems.v1;
using API.Models.ControllerResponse.ProductDetailInfos;
using ApplicationLayer.Requests.ProductDetailInfos.Queries;
using DomainLayer.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;
using RadesSoft.HateoasMaker.Extensions;

namespace API.Controllers.ProductDetailInfos.v1
{
	/// <summary>
	/// Product detail info  endpoints v1
	/// </summary>
	/// <seealso cref="BaseController{ProductDetailInfoEntity}"/>
	[ApiVersion("1")]
	public class ProductDetailInfosController : BaseController<ProductDetailInfosController>
	{
		public ProductDetailInfosController(IMediator mediator, ILogger<ProductDetailInfosController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}

		/// <summary>
		/// Get product detail info
		/// </summary>
		/// <param name="code">Product code</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns product detail info, if found
		/// </remarks>
		[HttpGet(Name = nameof(GetProductDetailInfoAsync))]
		[HateoasResponse("productDetailInfos_get", nameof(GetProductDetailInfoAsync), 1, "?code={code}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailInfoGetResponse>> GetProductDetailInfoAsync(string code, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailInfoGetRequest() { Code = code }, cancellationToken);

			var choices = new Dictionary<string, string?>();

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			var links = HateoasMaker.GetByNames(choices, ApiVersion);

			return Ok(result.GetResponseModel(links, orderCode));
		}
	}
}
