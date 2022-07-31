namespace UnitTests.MediatorRequestsTests.ProductDetails.Queries
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
	using Shouldly;
	using Xunit;

	public class ProductDetailGetTests : TestsBase
	{
		[Fact]
		public async void ProductDetailGetTest_Should_Pass()
		{
			var result = await new ProductDetailGetRequest.Handler(DbContext).Handle(new ProductDetailGetRequest { Id = 1 }, default);
			result.ProductCode.ShouldBe("AAAA0000");
		}


		[Fact]
		public async void ProductDetailGetTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailGetRequest.Handler(DbContext).Handle(new ProductDetailGetRequest { Id = 1 }, default);
			}
			catch(MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
