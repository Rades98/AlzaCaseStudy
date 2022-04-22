namespace API.Controllers.v1
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Products endpoint v1
    /// </summary>
    /// <seealso cref="BaseController{ProductEntity}"/>
    [ApiVersion("1")]
    public class ProductsController : BaseController<ProductEntity>
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns all products, if there is none, returns null
        /// </remarks>
        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProducts(CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await Mediator.Send(new ProductsGetRequest() { OrderBy = p => p.Name }, cancellationToken);

                if (results.Any())
                {
                    return Ok(results);
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
        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductGetResponse?>> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await Mediator.Send(new ProductGetRequest() { Id = id }, cancellationToken);
                if (results is not null)
                {
                    return Ok(results);
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
        [HttpPatch]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductUpdateResponse>> Update(Guid id, string description, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await Mediator.Send(new ProductUpdateRequest { Id = id, Description = description }, cancellationToken);

                if (result.Updated)
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
    }
}
