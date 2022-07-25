namespace API.Controllers.ProductDetailInfos.v1
{
	using API.Constants;
	using API.Controllers.OrderItems.v1;
	using ApplicationLayer.Requests.ProductDetailInfos.Queries;
	using DomainLayer.Entities.Product;
	using MediatR;
	using Microsoft.AspNetCore.Mvc;
	using RadesSoft.HateoasMaker;
	using RadesSoft.HateoasMaker.Attributes;
	using RadesSoft.HateoasMaker.Extensions;

	/// <summary>
	/// Product detail info  endpoints v1
	/// </summary>
	/// <seealso cref="BaseController{ProductDetailInfoEntity}"/>
	[ApiVersion("1")]
	public class ProductDetailInfosController : BaseController<ProductDetailInfoEntity>
	{
		public ProductDetailInfosController(IMediator mediator, ILogger<ProductDetailInfoEntity> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}


		/// <summary>
		/// Get product detail info
		/// </summary>
		/// <param name="id">Product detail ingo id </param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns product detail info, if found
		/// </remarks>
		[HttpGet(Name = nameof(GetProductDetailInfoAsync))]
		[HateoasResponse("productDetailInfos_get", nameof(GetProductDetailInfoAsync), 1, "?id={id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<ProductDetailInfoGetResponse>>> GetProductDetailInfoAsync(int id, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailInfoGetRequest() { Id = id }, cancellationToken);

			var choices = new Dictionary<string, string?>
				{
					{ nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart" },
					{ nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart" },
				};

			var links = HateoasMaker.GetByNames(choices, Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1);

			links.First(x => x.ActionName == "self").ReplaceInLink("{id}", result.Id.ToString());

			var cookieOrderCode = GetCookieValue(CookieNames.ActualOrder);

			if (cookieOrderCode is not null)
			{
				links.First(x => x.ActionName == "onAddToCart").ReplaceInLink("{orderCode}", cookieOrderCode, "{productCode}", result.ProductCode);
				links.First(x => x.ActionName == "onRemoveFromCart").ReplaceInLink("{orderCode}", cookieOrderCode, "{productCode}", result.ProductCode);
			}

			result.Links = links;

			return Ok(result);
		}
	}
}
