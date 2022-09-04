using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
using Shouldly;
using Xunit;

namespace UnitTests.MediatorRequestsTests.ProductDetails.Queries
{
	public class ProductDetailsGetTests : TestsBase
	{
		[Fact]
		public async void ProductDetailsGetTest_Should_Pass()
		{
			var results = await new ProductDetailsGetRequest.Handler(ProductDetailsRepo).Handle(new ProductDetailsGetRequest() { OrderBy = p => p.Name }, default);

			results.ShouldNotBeNull();
			results.ShouldNotBeEmpty();
		}
	}
}
