namespace UnitTests.MediatorRequestsTests.Orders.Commands
{
	using System;
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.Orders.Commands.ChangeStatus;
	using ApplicationSetting.Exceptions;
	using CodeLists.Exceptions;
	using Shouldly;
	using Xunit;

	public class OrderChangeStatusTests : TestsBase
	{
		[Fact]
		public async void ChangeOrderStatus_Should_Pass()
		{
			var result = await new OrderChangeStatusRequest.Handler(OrdersRepo).Handle(new OrderChangeStatusRequest() { OrderCode = "AAAAA00001", UserId = 2, StatusId = 2 }, default);

			result.Message.ShouldNotBeNull();
		}

		[Fact]
		public async void ChangeOrderStatus_Raise_Error_UnAuthorized()
		{
			try
			{
				var result = await new OrderChangeStatusRequest.Handler(OrdersRepo).Handle(new OrderChangeStatusRequest() { OrderCode = "AAAAA00001", UserId = 1, StatusId = 2 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}

		[Fact]
		public async void ChangeOrderStatus_Raise_Error_NotFound_Order()
		{
			try
			{
				var result = await new OrderChangeStatusRequest.Handler(OrdersRepo).Handle(new OrderChangeStatusRequest() { OrderCode = "AAAAA00010", UserId = 2, StatusId = 2 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		[Fact]
		public async void ChangeOrderStatus_Raise_Error_NotFound_Status()
		{
			try
			{
				var result = await new OrderChangeStatusRequest.Handler(OrdersRepo).Handle(new OrderChangeStatusRequest() { OrderCode = "AAAAA00001", UserId = 2, StatusId = 99 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		[Fact]
		public async void ChangeOrderStatus_Raise_Error_NotModified()
		{
			try
			{
				var result = await new OrderChangeStatusRequest.Handler(OrdersRepo).Handle(new OrderChangeStatusRequest() { OrderCode = "AAAAA00001", UserId = 2, StatusId = 5 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotModified);
			}
		}
	}
}
