namespace UnitTests.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks.MockRepoSetups;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductsGetQueryTests : ProductsGetRepositoryMock
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductsGetRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(ProductsGetRequest, CancellationToken.None);

            //Assert
            result.ToList().Count.ShouldBe(ProductsCount);
        }

        [Fact]
        public async void WhenNoneTest()
        {
            //Arrange
            var handler = new ProductsGetRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(ProductsGetRequestWhenNone, CancellationToken.None);

            //Assert
            result.ToList().Count.ShouldBe(0);
        }
    }
}
