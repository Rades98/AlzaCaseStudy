namespace UnitTests.Tests.Mediator.ProductDetails.Queries
{
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.ProductDetails;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductDetailsGetQueryTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductDetailsGetRequest.Handler(MockProvider<ProductDetailGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductsGetRequest, CancellationToken.None);

            //Assert
            result?.ToList().Count.ShouldBe(ProductDetailsRepositoryResultsMock.Products.Count);
        }

        [Fact]
        public async void WhenNoneTest()
        {
            //Arrange
            var handler = new ProductDetailsGetRequest.Handler(MockProvider<ProductDetailGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductsGetRequestWhenNone, CancellationToken.None);

            //Assert
            result.ShouldBe(null);
        }
    }
}
