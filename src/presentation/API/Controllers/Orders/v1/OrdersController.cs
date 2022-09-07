using API.Constants;
using API.Controllers.OrderItems.v1;
using API.Controllers.ProductDetails.v1;
using API.Models.ControllerResponse.Orders;
using API.Models.Orders;
using ApplicationLayer.Requests.Orders.Commands.ChangeStatus;
using ApplicationLayer.Requests.Orders.Commands.Put;
using ApplicationLayer.Requests.Orders.Commands.Storno;
using ApplicationLayer.Requests.Orders.Queries;
using CodeLists.UserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadesSoft.HateoasMaker;
using RadesSoft.HateoasMaker.Attributes;

namespace API.Controllers.Orders.v1
{
	[ApiVersion("1")]
	public class OrdersController : BaseController<OrdersController>
	{
		public OrdersController(IMediator mediator, ILogger<OrdersController> logger, HateoasMaker hateoasMaker) : base(mediator, logger, hateoasMaker)
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
		[HateoasResponse("orders_get", nameof(GetOrdersAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetOrdersAsync(CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken() }, cancellationToken);

			AddCookieWithActualOrder(result);

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
		[HttpGet("status", Name = nameof(GetOrdersFilteredAsync)), Authorize()]
		[HateoasResponse("orders_getByStatus", nameof(GetOrdersFilteredAsync), 1, "?statusId={statusId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<GetOrdersResult>> GetOrdersFilteredAsync(int statusId, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken(), WhereFilter = x => x.OrderStatusId == statusId }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductDetailsController.GetProductDetailByIdAsync), "getProduct" },
			};

			AddCookieWithActualOrder(result);

			return Ok(result.GetResponseModels(HateoasMaker.GetByNames(choices, ApiVersion), statusId));
		}

		/// <summary>
		/// Get active user orders
		/// </summary>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns all user orders where status id is as defined - for test purpose use Admin aJc48262_1Kjkz>X!
		/// </remarks>
		[HttpGet("active", Name = nameof(GetActiveOrdersAsync)), Authorize()]
		[HateoasResponse("orders_getActive", nameof(GetActiveOrdersAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetActiveOrdersAsync(CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken(), WhereFilter = x => CodeLists.OrderStatuses.OrderStatuses.Active.Contains(x.OrderStatusId) }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductDetailsController.GetProductDetailByIdAsync), "getProduct" },
			};

			return Ok(result.GetResponseModels(HateoasMaker.GetByNames(choices, ApiVersion)));
		}

		/// <summary>
		/// Get archive user orders
		/// </summary>
		/// <param name="cancellationToken">cancelation token</param>
		/// <remarks>
		/// Returns all user orders where status id is as defined - for test purpose use Admin aJc48262_1Kjkz>X!
		/// </remarks>
		[HttpGet("archive", Name = nameof(GetArchiveOrdersAsync)), Authorize()]
		[HateoasResponse("orders_getArchive", nameof(GetArchiveOrdersAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<OrdersGetResponse>>> GetArchiveOrdersAsync(CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersGetByUserRequest() { UserId = GetUserIdFromToken(), WhereFilter = x => CodeLists.OrderStatuses.OrderStatuses.Archive.Contains(x.OrderStatusId) }, cancellationToken);

			var choices = new Dictionary<string, string?>()
			{
				{ nameof(ProductDetailsController.GetProductDetailByIdAsync), "getProduct" },
			};

			return Ok(result.GetResponseModels(HateoasMaker.GetByNames(choices, ApiVersion)));
		}

		/// <summary>
		/// Create order
		/// </summary>
		/// <param name="cancellationToken">cancellation token</param>
		/// <remarks>
		/// Returns true if order was created
		/// </remarks>
		[HttpPut(Name = nameof(CreateOrderAsync)), Authorize()]
		[HateoasResponse("orders_create", nameof(CreateOrderAsync), 1)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<OrdersPutResponse>> CreateOrderAsync(CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrdersPutRequest() { UserId = GetUserIdFromToken() }, cancellationToken);

			AddCookieWithActualOrder(result);

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
		[HttpPatch(Name = nameof(ChangeOrderStatusAsync)), Authorize(Roles = UserRoles.Admin)]
		[HateoasResponse("orders_changeStatus", nameof(ChangeOrderStatusAsync), 1, "?orderCode={orderCode}&statusId={statusId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<OrderChangeStatusResponse>> ChangeOrderStatusAsync(string orderCode, [FromQuery] int statusId, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrderChangeStatusRequest() { OrderCode = orderCode, UserId = GetUserIdFromToken(), StatusId = statusId }, cancellationToken);

			RemoveActualOrderCookieIfNeeded(orderCode);

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
		[HttpDelete(Name = nameof(DeleteOrderAsync)), Authorize()]
		[HateoasResponse("orders_delete", nameof(DeleteOrderAsync), 1, "?orderCode={orderCode}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status408RequestTimeout)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<OrderStornoResponse>> DeleteOrderAsync(string orderCode, CancellationToken cancellationToken = default)
		{
			var result = await Mediator.Send(new OrderStornoRequest() { UserId = GetUserIdFromToken(), OrderCode = orderCode }, cancellationToken);

			RemoveActualOrderCookieIfNeeded(orderCode);

			return Ok(result);
		}

		private void AddCookieWithActualOrder(List<OrdersGetResponse> result)
		{
			var actual = result.FirstOrDefault(x => x.OrderStatus == CodeLists.OrderStatuses.OrderStatuses.New);

			if (actual is not null)
			{
				var cookieOptions = new CookieOptions()
				{
					Path = "/",
					Expires = DateTimeOffset.UtcNow.AddDays(1),
					IsEssential = true,
					HttpOnly = true,
					Secure = true,
				};

				Response.Cookies.Append(CookieNames.ActualOrder, actual.OrderCode, cookieOptions);
			}
		}

		private void AddCookieWithActualOrder(OrdersPutResponse result)
		{
			var cookieOptions = new CookieOptions()
			{
				Path = "/",
				Expires = DateTimeOffset.UtcNow.AddDays(1),
				IsEssential = true,
				HttpOnly = true,
				Secure = true,
			};

			Response.Cookies.Append(CookieNames.ActualOrder, result.OrderCode, cookieOptions);
		}

		private void RemoveActualOrderCookieIfNeeded(string orderCode)
		{
			string? cookieOrderCode;

			Request.Cookies.TryGetValue(CookieNames.ActualOrder, out cookieOrderCode);

			if (cookieOrderCode == orderCode)
			{
				Response.Cookies.Delete(CookieNames.ActualOrder);
			}
		}
	}
}
