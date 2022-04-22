namespace UnitTests.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks.MockRepoSetups;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductsGetPaginatedTests : ProductsGetPaginatedRepositoryMock
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductsGetPaginatedRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(ProductsGetPaginatedRequest, CancellationToken.None);

            //Assert
            result!.ToList().Count.ShouldBe(ProductsGetPaginatedRequest.PageSize);
        }
    }
}
