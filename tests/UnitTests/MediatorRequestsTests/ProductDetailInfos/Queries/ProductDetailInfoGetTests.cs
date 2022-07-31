namespace UnitTests.MediatorRequestsTests.ProductDetailInfos.Queries
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductDetailInfos.Queries;
	using Shouldly;
	using Xunit;

	public class ProductDetailInfoGetTests : TestsBase
	{
		[Fact]
		public async void ProductDetailInfoGetTest_Should_Pass()
		{
			var result = await new ProductDetailInfoGetRequest.Handler(DbContext).Handle(new ProductDetailInfoGetRequest() { Id = 1 }, default);
			result.ProductCode.ShouldBe("AAAA0000");
		}

		[Fact]
		public async void ProductDetailInfoGetTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailInfoGetRequest.Handler(DbContext).Handle(new ProductDetailInfoGetRequest() { Id = 9999999 }, default);
			}
			catch(MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
