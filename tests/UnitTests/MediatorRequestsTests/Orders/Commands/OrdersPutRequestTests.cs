namespace UnitTests.MediatorRequestsTests.Orders.Commands
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.Orders.Commands.Put;
	using Shouldly;
	using Xunit;

	public class OrdersPutRequestTests : TestsBase
	{
		[Fact]
		public async void OrdersPutTests_Should_Pass()
		{
			var result = await new OrdersPutRequest.Handler(DbContext).Handle(new OrdersPutRequest() { UserId = 3 }, default);

			result.Message.ShouldNotBeNull();
		}

		[Fact]
		public async void OrdersPutTests_Raise_Error()
		{
			try
			{
				var result = await new OrdersPutRequest.Handler(DbContext).Handle(new OrdersPutRequest() { UserId = 2 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.Error);
			}
		}
	}
}
