namespace API.Controllers.Products.v1
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Logging;
    using UserRolesCodeList;

    /// <summary>
    /// Products endpoint v1
    /// </summary>
    /// <seealso cref="BaseController{ProductEntity}"/>
    [ApiVersion("1")]
    public class ProductsController : BaseController<ProductEntity>
    {
        public ProductsController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<ProductEntity> logger) : base(mediator, adcp, logger)
        {
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns all products, if there is none, returns null
        /// </remarks>
        [HttpGet(Name = nameof(GetProductsAsync))]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var results = await Mediator.Send(new ProductsGetRequest() { OrderBy = p => p.Name }, cancellationToken);

            if (results.Any())
            {
                return Ok(results.Select(product => RestfullProductGetResponse(product)));
            }

            return NotFound();
        }

        /// <summary>
        /// Get product by its Id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns product found by id, if there is none, returns null
        /// </remarks>
        [HttpGet("{id}", Name = nameof(GetByIdAsync))]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductGetResponse?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new ProductGetRequest() { Id = id }, cancellationToken);
            if (result is not null)
            {
                return Ok(RestfullProductGetResponse(result));
            }

            return NotFound();
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
        [HttpPatch(Name = nameof(UpdateAsync)), Authorize(Roles = UserRoles.Admin)]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductUpdateResponse>> UpdateAsync(Guid id, string description, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new ProductUpdateRequest { Id = id, Description = description }, cancellationToken);

            if (result is not null && (result.Updated || result.UpToDate))
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        private ProductGetResponse RestfullProductGetResponse(ProductGetResponse response)
        {
            var all = UrlLink("all", nameof(GetProductsAsync));
            var self = UrlLink("_self", nameof(GetByIdAsync), new { id = response.Id });
            var update = UrlLink("update", nameof(UpdateAsync), new { id = response.Id, description = "new_description" });

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
