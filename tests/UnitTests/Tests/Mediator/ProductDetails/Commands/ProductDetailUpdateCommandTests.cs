namespace UnitTests.Tests.Mediator.ProductDetails.Commands
{
    using ApplicationLayer.Services.ProductDetails.Commands;
    using Mocks;
    using Mocks.GenericRepo.ProductDetails;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductDetailUpdateCommandTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductDetailUpdateRequest.Handler(MockProvider<ProductDetailUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductUpdateRequest, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(true);
        }

        [Fact]
        public async void AlreadyUpToDateTest()
        {
            //Arrange
            var handler = new ProductDetailUpdateRequest.Handler(MockProvider<ProductDetailUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductUpdateRequestUptoDate, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpToDate.ShouldBe(true);
            result.UpdateMessage.ShouldBe(ProductDetailCommandMessages.UpToDate);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductDetailUpdateRequest.Handler(MockProvider<ProductDetailUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductUpdateRequestNotFound, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpdateMessage.ShouldBe(ProductDetailCommandMessages.NotFound);
        }
    }
}
