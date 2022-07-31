﻿namespace UnitTests.MediatorRequestsTests.OrderItems.Commands.Put
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.OrderItems.Commands.Put;
	using Shouldly;
	using Xunit;

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
				var response = await new OrderItemPutRequest.Handler(DbContext).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00000", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotModified);
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
				var response = await new OrderItemPutRequest.Handler(DbContext).Handle(new OrderItemPutRequest() { OrderCode = "ZAAAA00000", ProductCode = "AAAA0000", UserId = 1 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
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
				var response = await new OrderItemPutRequest.Handler(DbContext).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "ZZZZ0000", UserId = 1 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}

		[Fact]
		/// <summary>
		/// Should pass
		/// </summary>
		public async void PutItem_Should_Pass()
		{
			var response = await new OrderItemPutRequest.Handler(DbContext).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 1 }, default);
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
				var response = await new OrderItemPutRequest.Handler(DbContext).Handle(new OrderItemPutRequest() { OrderCode = "AAAAA00002", ProductCode = "AAAA0000", UserId = 2 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}
	}
}