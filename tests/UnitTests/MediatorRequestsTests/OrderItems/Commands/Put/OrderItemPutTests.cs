using System;
using ApplicationLayer.Requests.OrderItems.Commands.Put;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.OrderItems.Commands.Put
{
	public class OrderItemPutTests : TestsBase
	{
		[Fact]
		/// <summary>
		/// Should return not modified due the fact, order is not editable at this moment
		/// </summary>
		public async void PutItem_Raise_Error_MptModified()
		{
			try
			{
				var response = await new OrderItemPutRequest.Handler(OrderItemsRepo).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00000", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotModified);
			}
		}

		/// <summary>
		/// Should return not found
		/// </summary>
		[Fact]
		public async void PutItem_Raise_Error_NotFound_Order()
		{
			try
			{
				var response = await new OrderItemPutRequest.Handler(OrderItemsRepo).Handle(new OrderItemPutRequest() { OrderCode = "ZAAAA00000", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		/// <summary>
		/// Should return not found
		/// </summary>
		[Fact]
		public async void PutItem_Raise_Error_NotFound_Product()
		{
			try
			{
				var response = await new OrderItemPutRequest.Handler(OrderItemsRepo).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "ZZZZ0000", UserId = 1 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		[Fact]
		/// <summary>
		/// Should pass
		/// </summary>
		public async void PutItem_Should_Pass()
		{
			var response = await new OrderItemPutRequest.Handler(OrderItemsRepo).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 1 }, default);
			response.Message.ShouldNotBeNull();
		}

		[Fact]
		/// <summary>
		/// Should return not modified due the fact, order is not editable at this moment
		/// </summary>
		public async void PutItem_Raise_Error_UnAuthorized()
		{
			try
			{
				var response = await new OrderItemPutRequest.Handler(OrderItemsRepo).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 2 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}
	}
}
