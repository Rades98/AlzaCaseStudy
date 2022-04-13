﻿namespace API.Controllers.v2
{
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Products endpoint v2
    /// </summary>
    /// <seealso cref="BaseController{ProductEntity}"/>
    [ApiVersion("2")]
    public class ProductController : BaseController<ProductEntity>
    {
        public ProductController(IMemoryCache cache, IMediator mediator) : base(cache, mediator)
        {
        }

        //Maybe it should be better to return blank list of ProductGetResponse
        /// <summary>
        /// Get all product paged by params
        /// </summary>
        /// <param name="pageSize">Number of records per page</param>
        /// <param name="pageNum">Number of page to show</param>
        /// <remarks>
        /// Returns paged products as specified, otherwise null
        /// </remarks>
        [HttpGet]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProducts(int pageSize, int pageNum)
        {
            try
            {
                var results = await Mediator.Send(new ProductsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = pageNum, PageSize = pageSize });
                if (results.Any())
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
    }
}