namespace UnitTests.Tests.Mediator.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.Products;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductGetQueryTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(MockProvider<ProductGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductGetRequest, CancellationToken.None);

            //Assert
            result.ShouldNotBe(null);
            result?.Id.ShouldBe(ProductsRepositoryRequestsMock.ProductGetRequest.Id);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(MockProvider<ProductGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductGetRequestNotFound, CancellationToken.None);

            //Assert
            result.ShouldBe(null);
        }
    }
}
