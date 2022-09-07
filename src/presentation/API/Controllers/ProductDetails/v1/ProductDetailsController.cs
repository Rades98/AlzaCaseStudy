using API.Constants;
using API.Controllers.OrderItems.v1;
using API.Controllers.ProductDetailInfos.v1;
using API.Models.ControllerResponse.ProductDetails;
using API.Models.ProductDetails;
using ApplicationLayer.Requests.ProductDetails.Commands;
using ApplicationLayer.Requests.ProductDetails.Queries;
using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
using CodeLists.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;
using RadesSoft.HateoasMaker.Extensions;

namespace API.Controllers.ProductDetails.v1
{
	/// <summary>
	/// Products endpoints v1
	/// </summary>
	/// <seealso cref="BaseController{ProductDetailEntity}"/>
	[ApiVersion("1")]
	public class ProductDetailsController : BaseController<ProductDetailsController>
	{
		public ProductDetailsController(IMediator mediator, ILogger<ProductDetailsController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}

		/// <summary>
		/// Get all products
		/// </summary>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns all products, if there is none, returns null
		/// </remarks>
		[HttpGet(Name = nameof(GetProductDetailsAsync))]
		[HateoasResponse("productDetais_get", nameof(GetProductDetailsAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailsGet>> GetProductDetailsAsync(CancellationToken cancellationToken = default)
		{
			var results = await Mediator.Send(new ProductDetailsGetRequest() { OrderBy = p => p.Name }, cancellationToken);

			var choices = new Dictionary<string, string?>
			{
				{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "productDetail" },
			};

			if (User.IsInRole(UserRoles.Admin))
			{
				choices.Add(nameof(UpdateProductDetailAsync), "updateDescription");
			}

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			return Ok(results.GetResponseModels(HateoasMaker.GetByNames(choices, ApiVersion), orderCode));
		}

		/// <summary>
		/// Get all product paged by params
		/// </summary>
		/// <param name="pageSize">Number of records per page</param>
		/// <param name="pageNum">Number of page to show</param>
		/// <param name="cancellationToken"></param>
		/// <remarks>
		/// Returns paged products as specified, otherwise null
		/// </remarks>
		[HttpGet("pag", Name = nameof(GetProductDetailsPaginatedAsync))]
		[HateoasResponse("productDetais_getPaged", nameof(GetProductDetailsPaginatedAsync), 1, "?pageSize={pageSize}&pageNum={pageNum}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailsGet>> GetProductDetailsPaginatedAsync(int pageSize, int pageNum, CancellationToken cancellationToken = default)
		{
			var results = await Mediator.Send(new ProductDetailsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = pageNum, PageSize = pageSize }, cancellationToken);

			var choices = new Dictionary<string, string?>
			{
				{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "productDetail" },
			};

			if (User.IsInRole(UserRoles.Admin))
			{
				choices.Add(nameof(UpdateProductDetailAsync), "updateDescription");
			}

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			return Ok(results.GetResponseModels(HateoasMaker.GetByNames(choices, ApiVersion), orderCode, pageSize, pageNum));
		}

		/// <summary>
		/// Get product by its Id
		/// </summary>
		/// <param name="code">Product code</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns product found by id, if there is none, returns null
		/// </remarks>
		[HttpGet("id", Name = nameof(GetProductDetailByIdAsync))]
		[HateoasResponse("productDetais_getById", nameof(GetProductDetailByIdAsync), 1, "?code={code}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailGetResponse?>> GetProductDetailByIdAsync(string code, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailGetRequest() { ProductCode = code }, cancellationToken);

			var choices = new Dictionary<string, string?>
			{
				{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "productDetail" },
			};

			if (User.IsInRole(UserRoles.Admin))
			{
				choices.Add(nameof(UpdateProductDetailAsync), "updateDescription");
			}

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			return Ok(result.GetResponseModel(HateoasMaker.GetByNames(choices, ApiVersion), orderCode));
		}

		/// <summary>
		/// Updates product description
		/// </summary>
		/// <param name="id">Product id </param>
		/// <param name="description">New description for optionally found Product</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns updated product if operation was succesfull, otherwise returns status
		/// </remarks>
		[HttpPatch(Name = nameof(UpdateProductDetailAsync)), Authorize(Roles = UserRoles.Admin)]
		[HateoasResponse("productDetais_update", nameof(UpdateProductDetailAsync), 1, "?id={id}&description={descrription}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailUpdateResponse>> UpdateProductDetailAsync(int id, string description, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailUpdateRequest { Id = id, Description = description }, cancellationToken);

			return Ok(result);
		}

		/// <summary>
		/// Search product
		/// </summary>
		/// <param name="phrase">phrase</param>
		/// <param name="pageSize">page size</param>
		/// <param name="pageNum">page num</param>
		/// <param name="cancellationToken">cancellation token</param>
		/// <returns></returns>
		[HttpPost(Name = nameof(SearchProduct))]
		[HateoasResponse("productDetais_search", nameof(SearchProduct), 1, "?phrase={phrase}&pageSize={pageSize}&pageNum={pageNum}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailSearch>> SearchProduct(string phrase, int pageSize, int pageNum, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailSearchRequest { Phrase = phrase, PageNum = pageNum, PageSize = pageSize }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "getDetail" },
			};

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			return Ok(result.GetSearchResponseModels(phrase, HateoasMaker.GetByNames(choices, ApiVersion), orderCode));
		}

		/// <summary>
		/// Search product
		/// </summary>
		/// <param name="catId">categoryId</param>
		/// <param name="pageSize">page size</param>
		/// <param name="pageNum">page num</param>
		/// <param name="cancellationToken">cancellation token</param>
		/// <returns></returns>
		[HttpPost("catId", Name = nameof(SearchProductByCategory))]
		[HateoasResponse("productDetais_searchByCat", nameof(SearchProductByCategory), 1, "?catId={catId}&pageSize={pageSize}&pageNum={pageNum}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailSearch>> SearchProductByCategory(int catId, int pageSize, int pageNum, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailsGetByCategory { CategoryId = catId, PageNum = pageNum, PageSize = pageSize }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "getDetail" },
			};

			var orderCode = GetCookieValue(CookieNames.ActualOrder);

			if (orderCode is not null)
			{
				choices.Add(nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart");
				choices.Add(nameof(OrderItemsController.DeleteOrderItemAsync), "onRemoveFromCart");
			}

			return Ok(result.GetSearchByCatIdResponseModels(catId, HateoasMaker.GetByNames(choices, ApiVersion), orderCode));
		}
	}
}
