namespace API.Controllers.Products.v1
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// Products endpoint v1
    /// </summary>
    /// <seealso cref="BaseController{ProductEntity}"/>
    [ApiVersion("1")]
    public class ProductsController : BaseController<ProductEntity>
    {
        public ProductsController(IMediator mediator, IActionDescriptorCollectionProvider adcp) : base(mediator, adcp)
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
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await Mediator.Send(new ProductsGetRequest() { OrderBy = p => p.Name }, cancellationToken);

                if (results.Any())
                {
                    return Ok(results.Select(product => RestfullProductGetResponse(product)));
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        public async Task<ActionResult<ProductGetResponse?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await Mediator.Send(new ProductGetRequest() { Id = id }, cancellationToken);
                if (result is not null)
                {
                    return Ok(RestfullProductGetResponse(result));
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        [HttpPatch(Name = nameof(UpdateAsync))]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductUpdateResponse>> UpdateAsync(Guid id, string description, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await Mediator.Send(new ProductUpdateRequest { Id = id, Description = description }, cancellationToken);

                if (result.Updated || result.UpToDate)
                {
                    return Ok(result);
                }

                return NotFound(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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
