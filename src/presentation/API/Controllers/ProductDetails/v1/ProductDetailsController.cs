namespace API.Controllers.ProductDetails.v1
{
	using API.Constants;
	using ApplicationLayer.Requests.ProductDetails.Commands;
	using ApplicationLayer.Requests.ProductDetails.Queries;
	using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
	using CodeLists.UserRoles;
	using DomainLayer.Entities.Product;
	using MediatR;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using OrderItems.v1;
	using ProductDetailInfos.v1;
	using RadesSoft.HateoasMaker;
	using RadesSoft.HateoasMaker.Attributes;
	using RadesSoft.HateoasMaker.Extensions;

	/// <summary>
	/// Products endpoints v1
	/// </summary>
	/// <seealso cref="BaseController{ProductDetailEntity}"/>
	[ApiVersion("1")]
	public class ProductDetailsController : BaseController<ProductDetailEntity>
	{
		public ProductDetailsController(IMediator mediator, ILogger<ProductDetailEntity> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
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
		public async Task<ActionResult<IEnumerable<ProductDetailGetResponse>>> GetProductDetailsAsync(CancellationToken cancellationToken = default)
		{
			var results = await Mediator.Send(new ProductDetailsGetRequest() { OrderBy = p => p.Name }, cancellationToken);

			results.ToList().ForEach(result =>
			{
				var choices = new Dictionary<string, string?>
				{
					{ nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart" },
					{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "productDetail" },
				};

				if (User.IsInRole(UserRoles.Admin))
				{
					choices.Add(nameof(UpdateProductDetailAsync), "updateDescription");
				}

				var links = HateoasMaker.GetByNames(choices, Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1);

				var cookieOrderCode = GetCookieValue(CookieNames.ActualOrder);

				if (cookieOrderCode is not null)
				{
					links.First(x => x.ActionName == "onAddToCart").ReplaceInLink("{orderCode}", cookieOrderCode, "{productCode}", result.ProductCode);
				}

				links.First(x => x.ActionName == "productDetail").ReplaceInLink("{id}", result.Id.ToString());

				result.Links = links;
			});

			return Ok(results);
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
		public async Task<ActionResult<IEnumerable<ProductDetailGetResponse>>> GetProductDetailsPaginatedAsync(int pageSize, int pageNum, CancellationToken cancellationToken = default)
		{
			var results = await Mediator.Send(new ProductDetailsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = pageNum, PageSize = pageSize }, cancellationToken);
			results.ToList().ForEach(result =>
			{
				var choices = new Dictionary<string, string?>
				{
					{ nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart" },
					{ nameof(ProductDetailInfosController.GetProductDetailInfoAsync), "productDetail" },
				};

				if (User.IsInRole(UserRoles.Admin))
				{
					choices.Add(nameof(UpdateProductDetailAsync), "updateDescription");
				}

				var links = HateoasMaker.GetByNames(choices, Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1);

				var cookieOrderCode = GetCookieValue(CookieNames.ActualOrder);

				if (cookieOrderCode is not null)
				{
					links.First(x => x.ActionName == "onAddToCart").ReplaceInLink("{orderCode}", cookieOrderCode, "{productCode}", result.ProductCode);
				}

				links.First(x => x.ActionName == "productDetail").ReplaceInLink("{id}", result.Id.ToString());

				result.Links = links;
			});
			return Ok(results);
		}

		/// <summary>
		/// Get product by its Id
		/// </summary>
		/// <param name="id">Product id</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns product found by id, if there is none, returns null
		/// </remarks>
		[HttpGet("id", Name = nameof(GetProductDetailByIdAsync))]
		[HateoasResponse("productDetais_getById", nameof(GetProductDetailByIdAsync), 1, "?id={id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDetailGetResponse?>> GetProductDetailByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductDetailGetRequest() { Id = id }, cancellationToken);

			var choices = new Dictionary<string, string?>
			{
				{ nameof(OrderItemsController.PutOrderItemAsync), "onAddToCart" },
			};

			var links = HateoasMaker.GetByNames(choices, Url.ActionContext.HttpContext.GetRequestedApiVersion()?.MajorVersion ?? 1);
			var cookieOrderCode = GetCookieValue(CookieNames.ActualOrder);

			if (cookieOrderCode is not null)
			{
				links.First(x => x.ActionName == "onAddToCart").ReplaceInLink("{orderCode}", cookieOrderCode, "{productCode}", result.ProductCode);
			}

			links.First(x => x.ActionName == "self").ReplaceInLink("{id}", result.Id.ToString());

			result.Links = links;

			return Ok(result);
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
	}
}
