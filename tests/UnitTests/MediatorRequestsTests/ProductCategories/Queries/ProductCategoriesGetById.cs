namespace UnitTests.MediatorRequestsTests.ProductCategories.Queries
{
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductCategories.Queries;
	using Shouldly;
	using Xunit;

	public class ProductCategoriesGetByIdTests : TestsBase
	{
		[Fact]
		public async void ProductCategoriesGetById_Shoul_Pass()
		{
			var result = await new ProductCategoriesGetByIdRequest.Handler(DbContext).Handle(new ProductCategoriesGetByIdRequest() { Id = 1 }, default);

			result.ShouldNotBeNull();
			result.CategoryTree.Id.ShouldBe(1);
			result.CategoryTree.Children.ShouldNotBeNull();
			result.CategoryTree.Children.Count.ShouldBe(2);
		}

		[Fact]
		public async void ProductCategoriesGetById_Raise_Error_NotFound()
		{
			try
			{
				var result = await new ProductCategoriesGetByIdRequest.Handler(DbContext).Handle(new ProductCategoriesGetByIdRequest() { Id = 1000 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
