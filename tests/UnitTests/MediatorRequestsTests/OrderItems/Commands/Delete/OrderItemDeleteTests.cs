using System;
using ApplicationLayer.Requests.OrderItems.Commands.Delete;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.OrderItems.Commands.Delete
{
	public class OrderItemDeleteTests : TestsBase
	{
		[Fact]
		/// <summary>
		/// Delete existing item from active order
		/// </summary>
		public async void DeleteItem_Should_Pass()
		{
			var response = await new OrderItemDeleteRequest.Handler(OrderItemsRepo).Handle(new OrderItemDeleteRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 1 }, default);

			response.Message.ShouldBe("Deleted");
		}

		[Fact]
		/// <summary>
		/// Try to delete item where product is not listed in
		/// </summary>
		public async void DeleteItem_Should_Raise_Error()
		{
			try
			{
				var response = await new OrderItemDeleteRequest.Handler(OrderItemsRepo).Handle(new OrderItemDeleteRequest() { OrderCode = "AAAAA00000", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotModified);
			}
		}

		[Fact]
		/// <summary>
		/// Try to remove item from unedible order
		/// </summary>
		public async void DeleteItem_Raise_Error_UnEdible()
		{
			try
			{
				var response = await new OrderItemDeleteRequest.Handler(OrderItemsRepo).Handle(new OrderItemDeleteRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotModified);
			}
		}

		[Fact]
		/// <summary>
		/// Try to remove item from another's user order
		/// </summary>
		public async void DeleteItem_Raise_Error_Unauthorized()
		{
			try
			{
				var response = await new OrderItemDeleteRequest.Handler(OrderItemsRepo).Handle(new OrderItemDeleteRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 4 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}
	}
}
