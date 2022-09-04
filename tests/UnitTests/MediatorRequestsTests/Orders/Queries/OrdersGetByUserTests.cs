using System.Linq;
using ApplicationLayer.Requests.Orders.Queries;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.Orders.Queries
{
	public class OrdersGetByUserTests : TestsBase
	{
		[Fact]
		public async void OrdersGetByUserTests_Should_Pass()
		{
			var result = await new OrdersGetByUserRequest.Handler(OrdersRepo).Handle(new OrdersGetByUserRequest() { UserId = 2, }, default);

			result.Count.ShouldBe(1);
			result.First().OrderCode.ShouldBe("AAAAA00001");
		}
	}
}
