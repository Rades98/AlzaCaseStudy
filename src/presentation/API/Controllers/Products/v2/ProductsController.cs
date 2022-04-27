﻿namespace API.Controllers.Products.v2
{
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// Products endpoint v2
    /// </summary>
    /// <seealso cref="BaseController{ProductEntity}"/>
    [ApiVersion("2")]
    public class ProductsController : BaseController<ProductEntity>
    {
        public ProductsController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<ProductEntity> logger) : base(mediator, adcp, logger)
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
        public async Task<ActionResult<IEnumerable<ProductGetResponse>>> GetProductsAsync(int pageSize, int pageNum, CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await Mediator.Send(new ProductsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = pageNum, PageSize = pageSize }, cancellationToken);
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

        private ProductGetResponse RestfullProductGetResponse(ProductGetResponse response)
        {
            var all = UrlLink("all", nameof(GetProductsAsync), new { pageSize = 10, pageNum = 1 });
            var self = UrlLink("_self", nameof(v1.ProductsController.GetByIdAsync), new { id = response.Id });
            var update = UrlLink("update", nameof(v1.ProductsController.UpdateAsync), new { id = response.Id, description = "new_description" });

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