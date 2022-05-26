namespace UnitTests.Tests.Mediator.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.Products;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductsGetQueryTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductsGetRequest.Handler(MockProvider<ProductGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductsGetRequest, CancellationToken.None);

            //Assert
            result?.ToList().Count.ShouldBe(ProductsRepositoryResultsMock.Products.Count);
        }

        [Fact]
        public async void WhenNoneTest()
        {
            //Arrange
            var handler = new ProductsGetRequest.Handler(MockProvider<ProductGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductsGetRequestWhenNone, CancellationToken.None);

            //Assert
            result.ShouldBe(null);
        }
    }
}
