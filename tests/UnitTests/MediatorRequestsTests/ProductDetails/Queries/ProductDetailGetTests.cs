namespace UnitTests.MediatorRequestsTests.ProductDetails.Queries
{
	using System;
	using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
	using ApplicationSetting.Exceptions;
	using CodeLists.Exceptions;
	using Shouldly;
	using Xunit;

	public class ProductDetailGetTests : TestsBase
	{
		[Fact]
		public async void ProductDetailGetTest_Should_Pass()
		{
			var result = await new ProductDetailGetRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailGetRequest { ProductCode = "AAAA0000" }, default);
			result.ProductCode.ShouldBe("AAAA0000");
		}


		[Fact]
		public async void ProductDetailGetTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailGetRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailGetRequest { ProductCode = "ZZZZZZZZ" }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
