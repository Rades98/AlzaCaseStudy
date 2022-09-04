namespace UnitTests.MediatorRequestsTests.ProductDetailInfos.Queries
{
	using System;
	using ApplicationLayer.Requests.ProductDetailInfos.Queries;
	using ApplicationSetting.Exceptions;
	using CodeLists.Exceptions;
	using Shouldly;
	using Xunit;

	public class ProductDetailInfoGetTests : TestsBase
	{
		[Fact]
		public async void ProductDetailInfoGetTest_Should_Pass()
		{
			var result = await new ProductDetailInfoGetRequest.Handler(OrderItemsRepo, ProductDetailInfosRepo, ProductsRepo).Handle(new ProductDetailInfoGetRequest() { Code = "AAAA0000" }, default);
			result.ProductCode.ShouldBe("AAAA0000");
		}

		[Fact]
		public async void ProductDetailInfoGetTest_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductDetailInfoGetRequest.Handler(OrderItemsRepo, ProductDetailInfosRepo, ProductsRepo).Handle(new ProductDetailInfoGetRequest() { Code = "ZZZZZZZZ" }, default);
			}
			catch (Exception e)
			{
				((IApplicationException)e).Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
