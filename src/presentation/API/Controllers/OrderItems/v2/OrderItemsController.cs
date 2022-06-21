namespace API.Controllers.OrderItems.v2
{
    using ApplicationLayer.ServicesDapper.OrderItems.Commands.Delete;
   // using ApplicationLayer.ServicesDapper.OrderItems.Commands.Put;
    using DomainLayer.Entities.Orders;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    [ApiVersion("2")]
    public class OrderItemsController : BaseController<OrderItemEntity>
    {
        public OrderItemsController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<OrderItemEntity> logger) : base(mediator, adcp, logger)
        {
        }

        ///// <summary>
        ///// Add article to order
        ///// </summary>
        ///// <param name="productCode">Product code</param>
        ///// <param name="orderCode">order code</param>
        ///// <param name="cancellationToken">cancellation token</param>
        ///// <remarks>
        ///// Adds article to order
        ///// </remarks>
        //[HttpPut("orderCode", Name = nameof(PutOrderItemAsync)), Authorize()]
        //[MapToApiVersion("2")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<OrderItemPutResponse>> PutOrderItemAsync(string orderCode, [FromQuery] string productCode, CancellationToken cancellationToken = default)
        //{
        //    var result = await Mediator.Send(new OrderItemPutRequest() { UserId = GetUserIdFromToken(), ProductCode = productCode, OrderCode = orderCode }, cancellationToken);

        //    return Ok(result);
        //}

        /// <summary>
        /// Remove article from order
        /// </summary>
        /// <param name="productCode">Product code</param>
        /// <param name="orderCode">order code</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <remarks>
        /// Remove article from order
        /// </remarks>
        [HttpDelete("orderCode", Name = nameof(DeleteOrderItemAsync)), Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderItemDeleteResponse>> DeleteOrderItemAsync(string orderCode, [FromQuery] string productCode, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrderItemDeleteRequest() { UserId = GetUserIdFromToken(), ProductCode = productCode, OrderCode = orderCode }, cancellationToken);

            return Ok(result);
        }
    }
}
