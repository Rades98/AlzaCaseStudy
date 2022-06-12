namespace API.Controllers.ProductDetails.v2
{
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using ApplicationLayer.Services.ProductDetails.Queries;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// Products endpoints v2
    /// </summary>
    /// <seealso cref="BaseController{ProductDetailEntity}"/>
    [ApiVersion("2")]
    public class ProductDetailsController : BaseController<ProductDetailEntity>
    {
        public ProductDetailsController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<ProductDetailEntity> logger) : base(mediator, adcp, logger)
        {
        }

        //Maybe it should be better to return blank list of ProductGetResponse
        /// <summary>
        /// Get all product paged by params
        /// </summary>
        /// <param name="pageSize">Number of records per page</param>
        /// <param name="pageNum">Number of page to show</param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// Returns paged products as specified, otherwise null
        /// </remarks>
        [HttpGet(Name = nameof(GetProductsAsync))]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDetailGetResponse>>> GetProductsAsync(int pageSize, int pageNum, CancellationToken cancellationToken = default)
        {
            var results = await Mediator.Send(new ProductDetailsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = pageNum, PageSize = pageSize }, cancellationToken);
            return Ok(results.Select(product => RestfullProductGetResponse(product)));
        }

        private ProductDetailGetResponse RestfullProductGetResponse(ProductDetailGetResponse response)
        {
            var all = UrlLink("all", nameof(GetProductsAsync), new { pageSize = 10, pageNum = 1 });
            var self = UrlLink("_self", nameof(v1.ProductDetailsController.GetByIdAsync), new { id = response.Id });
            var update = UrlLink("update", nameof(v1.ProductDetailsController.UpdateAsync), new { id = response.Id, description = "new_description" });

            if (all is not null)
            {
                response.Links.Add(all);
            }

            if (self is not null)
            {
                response.Links.Add(self);
            }

            if (update is not null)
            {
                response.Links.Add(update);
            }

            return response;
        }
    }
}