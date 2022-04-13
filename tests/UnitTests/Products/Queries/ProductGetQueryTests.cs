namespace UnitTests.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks.MockRepoSetups;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductGetQueryTests : ProductGetRepositoryMock
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(new ProductGetRequest() { Id = ProductGetRequest.Id }, CancellationToken.None);

            //Assert
            result.ShouldNotBe(null);
            result?.Id.ShouldBe(ProductGetRequest.Id);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(new ProductGetRequest() { Id = ProductGetRequestNotFound.Id }, CancellationToken.None);

            //Assert
            result.ShouldBe(null);
        }
    }
}
