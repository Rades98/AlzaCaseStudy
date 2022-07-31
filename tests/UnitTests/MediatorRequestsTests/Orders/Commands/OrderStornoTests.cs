namespace UnitTests.MediatorRequestsTests.Orders.Commands
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.Orders.Commands.Storno;
	using Shouldly;
	using Xunit;

	public class OrderStornoTests : TestsBase
	{
		[Fact]
		public async void OrderStornoTest_Should_Pass()
		{
			var result = await new OrderStornoRequest.Handler(DbContext).Handle(new OrderStornoRequest() { UserId = 4, OrderCode = "AAAAA00003" }, default);

			result.Message.ShouldNotBeNull();
		}

		[Fact]
		public async void OrderStornoTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new OrderStornoRequest.Handler(DbContext).Handle(new OrderStornoRequest() { UserId = 4, OrderCode = "ZZZZZ00003" }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}


		[Fact]
		public async void OrderStornoTest_Raise_Error_UnAuthorized()
		{
			try
			{
				var result = await new OrderStornoRequest.Handler(DbContext).Handle(new OrderStornoRequest() { UserId = 4, OrderCode = "AAAAA00002" }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.Unauthorized);
			}
		}
	}
}
