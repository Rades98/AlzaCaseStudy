using ApplicationLayer.Requests.OrderItems.Commands.Delete;
using ApplicationLayer.Requests.OrderItems.Commands.Put;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;

namespace API.Controllers.OrderItems.v1
{
	[ApiVersion("1")]
	public class OrderItemsController : BaseController<OrderItemsController>
	{
		public OrderItemsController(IMediator mediator, ILogger<OrderItemsController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
		{
		}

		/// <summary>
		/// Add article to order
		/// </summary>
		/// <param name="productCode">Product code</param>
		/// <param name="orderCode">order code</param>
		/// <param name="cancellationToken">cancellation token</param>
		/// <remarks>
		/// Adds article to order
		/// </remarks>
		[HttpPut(Name = nameof(PutOrderItemAsync)), Authorize()]
		[HateoasResponse("orderItem_put", nameof(PutOrderItemAsync), 1, "?orderCode={orderCode}&productCode={productCode}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<OrderItemPutResponse>> PutOrderItemAsync(string orderCode, [FromQuery] string productCode, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrderItemPutRequest() { UserId = GetUserIdFromToken(), ProductCode = productCode, OrderCode = orderCode }, cancellationToken);

			return Ok(result);
		}

		/// <summary>
		/// Remove article from order
		/// </summary>
		/// <param name="productCode">Product code</param>
		/// <param name="orderCode">order code</param>
		/// <param name="cancellationToken">cancellation token</param>
		/// <remarks>
		/// Remove article from order
		/// </remarks>
		[HttpDelete(Name = nameof(DeleteOrderItemAsync)), Authorize()]
		[HateoasResponse("orderItem_Delete", nameof(DeleteOrderItemAsync), 1, "?orderCode={orderCode}&productCode={productCode}")]
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
