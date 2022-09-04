namespace UnitTests.MediatorRequestsTests.ProductCategories.Queries
{
	using ApplicationLayer.Requests.ProductCategories.Queries;
	using Shouldly;
	using Xunit;

	public class ProductCategoriesGetTests : TestsBase
	{
		[Fact]
		public async void ProductCategoriesGetBy_Should_Pass()
		{
			var result = await new ProductCategoriesGetRequest.Handler(ProductCategoriesRepo).Handle(new ProductCategoriesGetRequest() { }, default);

			result.ShouldNotBeNull();
			result.CategoryTree.Id.ShouldBe(1);
			result.CategoryTree.Children.ShouldNotBeNull();
			result.CategoryTree.Children.Count.ShouldBe(2);
		}
	}
}
