using System;
using ApplicationLayer.Requests.Orders.Commands.Put;
using ApplicationSetting.Exceptions;
using CodeLists.Exceptions;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.Orders.Commands
{
	public class OrdersPutRequestTests : TestsBase
	{
		[Fact]
		public async void OrdersPutTests_Should_Pass()
		{
			var result = await new OrdersPutRequest.Handler(OrdersRepo).Handle(new OrdersPutRequest() { UserId = 3 }, default);

			result.Message.ShouldNotBeNull();
		}

		[Fact]
		public async void OrdersPutTests_Raise_Error()
		{
			try
			{
				var result = await new OrdersPutRequest.Handler(OrdersRepo).Handle(new OrdersPutRequest() { UserId = 2 }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.Error);
			}
		}
	}
}
