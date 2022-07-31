namespace UnitTests.MediatorRequestsTests.ProductDetails.Queries
{
	using System.Linq;
	using ApplicationLayer.Exceptions;
	using ApplicationLayer.Requests.ProductDetails.Queries.Requests;
	using Shouldly;
	using Xunit;

	public class ProductDetailsGetPaginatedTests : TestsBase
	{
		[Fact]
		public async void ProductDetailsGetPaginatedTest_Should_Pass()
		{
			var results = await new ProductDetailsGetPaginatedRequest.Handler(DbContext).Handle(new ProductDetailsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = 1, PageSize = 5 }, default);

			results.Count().ShouldBe(5);
			results.ShouldNotBeEmpty();
			results.ShouldNotBeNull();
		}

		[Fact]
		public async void ProductDetailsGetPaginatedTest_Raise_Error_NotFound()
		{
			try
			{
				var results = await new ProductDetailsGetPaginatedRequest.Handler(DbContext).Handle(new ProductDetailsGetPaginatedRequest() { OrderBy = p => p.Name, PageNumber = 100, PageSize = 5 }, default);
			}
			catch (MediatorException e)
			{
				e.Type.ShouldBe(ExceptionType.NotFound);
			}
		}
	}
}
