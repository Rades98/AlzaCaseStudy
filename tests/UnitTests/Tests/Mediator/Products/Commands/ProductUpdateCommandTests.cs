namespace UnitTests.Tests.Mediator.Products.Commands
{
    using ApplicationLayer.Services.Product.Commands;
    using Mocks;
    using Mocks.GenericRepo.Products;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductUpdateCommandTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(MockProvider<ProductUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductUpdateRequest, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(true);
        }

        [Fact]
        public async void AlreadyUpToDateTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(MockProvider<ProductUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductUpdateRequestUptoDate, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpToDate.ShouldBe(true);
            result.UpdateMessage.ShouldBe(ProductCommandMessages.UpToDate);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(MockProvider<ProductUpdateRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductUpdateRequestNotFound, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpdateMessage.ShouldBe(ProductCommandMessages.NotFound);
        }
    }
}
