using API.Controllers.ProductDetails.v1;
using API.Models.ControllerResponse.ProductCategories;
using ApplicationLayer.Dtos;
using ApplicationLayer.Requests.ProductCategories.Queries;
using DomainLayer.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;
using RadesSoft.HateoasMaker.Extensions;
using RadesSoft.HateoasMaker.Models;

namespace API.Controllers.ProductCategories.v1
{
	[ApiVersion("1")]
	public class ProductCategoriesController : BaseController<ProductCategoriesController>
	{
		public ProductCategoriesController(IMediator mediator, ILogger<ProductCategoriesController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}

		/// <summary>
		/// Get product categories
		/// </summary>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns product categories
		/// </remarks>
		[HttpGet(Name = nameof(GetProductCategopriesAsync))]
		[HateoasResponse("productCategories_get", nameof(GetProductCategopriesAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<ProductCategoriesGetResponse>>> GetProductCategopriesAsync(CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductCategoriesGetByIdRequest() { Id = CodeLists.ProductCategories.ProductCategories.EshopId }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductCategoriesController.GetProductCategoriesByIdAsync), "getCategories" },
				{ nameof(ProductDetailsController.SearchProductByCategory), "getProductsByCategory" },
			};

			return Ok(result.GetResponseModel(HateoasMaker.GetByNames(choices, ApiVersion)));
		}

		/// <summary>
		/// Get subcategories for category
		/// </summary>
		/// <param name="id">category Id</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns subcategories for defined category
		/// </remarks>
		[HttpGet("id", Name = nameof(GetProductCategoriesByIdAsync))]
		[HateoasResponse("productCategories_getById", nameof(GetProductCategoriesByIdAsync), 1, "?id={id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<ProductCategoriesGetResponse>>> GetProductCategoriesByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new ProductCategoriesGetByIdRequest() { Id = id }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductCategoriesController.GetProductCategoriesByIdAsync), "getCategories" },
				{ nameof(ProductDetailsController.SearchProductByCategory), "getProductsByCategory" },
			};

			return Ok(result.GetResponseModel(HateoasMaker.GetByNames(choices, ApiVersion)));
		}
	}
}



