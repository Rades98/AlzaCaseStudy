namespace API.Controllers.ProductCategories.v1
{
    using ApplicationLayer.Services.ProductCategories.Queries;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    public class ProductCategoriesController : BaseController<ProductCategoryEntity>
    {
        public ProductCategoriesController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<ProductCategoryEntity> logger) : base(mediator, adcp, logger)
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
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductCategoriesGetResponse>>> GetProductCategopriesAsync(CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new ProductCategoriesGetRequest() { }, cancellationToken);

            if (result is not null)
            {
                return Ok(RestfullProductCategoriesGetResponse(result));
            }

            return NotFound();
        }

        /// <summary>
        /// Get subcategories for category
        /// </summary>
        /// <param name="id">category Id</param>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns subcategories for defined category
        /// </remarks>
        [HttpGet("{id}", Name = nameof(GetProductCategoriesByIdAsync))]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductCategoriesGetResponse>>> GetProductCategoriesByIdAsync(Guid id,CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new ProductCategoriesGetByIdRequest() { Id = id }, cancellationToken);

            if (result is not null)
            {
                return Ok(RestfullProductCategoriesGetResponse(result));
            }

            return NotFound();
        }

        private ProductCategoriesGetResponse RestfullProductCategoriesGetResponse(ProductCategoriesGetResponse response)
        {
            var all = UrlLink("all", nameof(GetProductCategopriesAsync));
            var self = UrlLink("_self", nameof(GetProductCategoriesByIdAsync), new { id = "GUID_HERE" });

            if (all is not null)
            {
                response.Links.Add(all);
            }

            if (self is not null)
            {
                response.Links.Add(self);
            }

            return response;
        }
    }
}



