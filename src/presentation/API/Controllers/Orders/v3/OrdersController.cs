namespace API.Controllers.Orders.v3
{
	using ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser;
	using OrdersGetByUserRequest = ApplicationLayer.RequestsDapper.Orders.Queries.OrdersGetByUser.Localized.OrdersGetByUserRequest;
	using DomainLayer.Entities.Orders;
	using MediatR;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;

	[ApiVersion("3")]
	public class OrdersController : BaseController<OrderEntity>
	{
		public OrdersController(IMediator mediator, IActionDescriptorCollectionProvider adcp, ILogger<OrderEntity> logger) : base(mediator, adcp, logger)
		{
		}

		/// <summary>
		/// Get all user orders
		/// </summary>
		/// <param name="languageCode">language code</param>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns all user orders - for test purpose use Admin aJc48262_1Kjkz>X!
		/// </remarks>
		[HttpGet(Name = nameof(GetOrdersAsync)), Authorize()]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetOrdersAsync(string languageCode, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken(), LanguageCode = languageCode }, cancellationToken);

			return Ok(result);
		}
	}
}
