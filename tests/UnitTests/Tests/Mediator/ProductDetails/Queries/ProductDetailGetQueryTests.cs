namespace UnitTests.Tests.Mediator.ProductDetails.Queries
{
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.ProductDetails;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductDetailGetQueryTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductDetailGetRequest.Handler(MockProvider<ProductDetailGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductGetRequest, CancellationToken.None);

            //Assert
            result.ShouldNotBe(null);
            result?.Id.ShouldBe(ProductDetailsRepositoryRequestsMock.ProductGetRequest.Id);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductDetailGetRequest.Handler(MockProvider<ProductDetailGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductGetRequestNotFound, CancellationToken.None);

            //Assert
            result.ShouldBe(null);
        }
    }
}
