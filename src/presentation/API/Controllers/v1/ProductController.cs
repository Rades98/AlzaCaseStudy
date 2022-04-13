namespace API.Controllers.v1
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Cache;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    [ApiVersion("1")]
    public class ProductController : BaseController<ProductEntity>
    {
        public ProductController(IMemoryCache cache, IMediator mediator) : base(cache, mediator)
        {
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProducts()
        {
            try
            {
                if (!CacheProvider.TryGetValue(CacheKeys.Products, out IEnumerable<ProductGetResponse> products))
                {
                    var results = await Mediator.Send(new ProductsGetRequest() { OrderBy = p => p.Name });
                    if (results.Any())
                    {
                        CacheProvider.Set(CacheKeys.Products, results, CacheEntryOptions.Default);
                        return Ok(results);
                    }
                }
                else
                {
                    return Ok(products);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{Id}")]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductGetResponse?>> GetById(Guid id)
        {
            try
            {
                var results = await Mediator.Send(new ProductGetRequest() { Id = id });
                if (results is not null)
                {
                    return Ok(results);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductUpdateResponse>> Update(Guid id, string description)
        {
            try
            {
                var result = await Mediator.Send(new ProductUpdateRequest { Id = id, Description = description });

                if (result.Updated)
                {
                    return Ok(result);
                }
                else if (result.UpToDate)
                {
                    return NoContent();
                }

                return NotFound(result);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

        }
    }
}
