namespace API.Controllers.Orders.v1
{
    using ApplicationLayer.Services.Orders.Commands.ChangeStatus;
    using ApplicationLayer.Services.Orders.Commands.Put;
    using ApplicationLayer.Services.Orders.Commands.Storno;
    using ApplicationLayer.Services.Orders.Queries;
    using DomainLayer.Entities.Orders;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    public class OrdersController : BaseController<OrderEntity>
    {
        public OrdersController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<OrderEntity> logger) : base(mediator, adcp, logger)
        {
        }

        /// <summary>
        /// Get all user orders
        /// </summary>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns all user orders - for test purpose use Admin aJc48262_1Kjkz>X!
        /// </remarks>
        [HttpGet(Name = nameof(GetOrdersAsync)), Authorize()]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetOrdersAsync(CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken() }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Get all user orders
        /// </summary>
        /// <param name="statusId">Order status Id</param>
        /// <param name="cancellationToken">cancelation token</param>
        /// <remarks>
        /// Returns all user orders where status id is as defined - for test purpose use Admin aJc48262_1Kjkz>X!
        /// </remarks>
        [HttpGet("statusId", Name = nameof(GetOrdersFilteredAsync)), Authorize()]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetOrdersFilteredAsync(Guid statusId, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken(), WhereFilter = x => x.OrderStatusId == statusId }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <remarks>
        /// Returns true if order was created
        /// </remarks>
        [HttpPut(Name = nameof(CreateOrderAsync)), Authorize()]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrdersPutResponse>> CreateOrderAsync(CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrdersPutRequest() { UserId = GetUserIdFromToken() }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Changes order status
        /// </summary>
        /// <param name="orderCode">order code</param>
        /// <param name="statusId">new status</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <remarks>
        /// Changes order status
        /// </remarks>
        [HttpPatch("orderCode", Name = nameof(ChangeOrderStatusAsync)), Authorize()]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderChangeStatusResponse>> ChangeOrderStatusAsync(string orderCode, [FromQuery] Guid statusId, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrderChangeStatusRequest() { OrderCode = orderCode, UserId = GetUserIdFromToken(), StatusId = statusId }, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Storno order
        /// </summary>
        /// <param name="orderCode">order code</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <remarks>
        /// Storno order
        /// </remarks>
        [HttpDelete("OrderCode", Name = nameof(DeleteOrderAsync)), Authorize()]
        [MapToApiVersion("1")]
        [MapToApiVersion("2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderStornoResponse>> DeleteOrderAsync(string orderCode, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new OrderStornoRequest() { UserId = GetUserIdFromToken(), OrderCode = orderCode }, cancellationToken);

            return Ok(result);
        }
    }
}
