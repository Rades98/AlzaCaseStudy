namespace API.Controllers.ProductDetailInfos.v1
{
    using ApplicationLayer.Services.ProductDetailInfos.Queries;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// Product detail info  endpoints v1
    /// </summary>
    /// <seealso cref="BaseController{ProductDetailInfoEntity}"/>
    public class ProductDetailInfosController : BaseController<ProductDetailInfoEntity>
    {
        public ProductDetailInfosController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<ProductDetailInfoEntity> logger) : base(mediator, adcp, logger)
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
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDetailInfoGetResponse>>> GetProductDetailInfoAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new ProductDetailInfoGetRequest() { Id = id }, cancellationToken);

            return Ok(RestfullProductDetailInfoGetResponse(result));

        }

        private ProductDetailInfoGetResponse RestfullProductDetailInfoGetResponse(ProductDetailInfoGetResponse response)
        {
            var self = UrlLink("_self", nameof(GetProductDetailInfoAsync), new { id = response.Id });

            if (self is not null)
            {
                response.Links.Add(self);
            }

            return response;
        }
    }
}
