namespace UnitTests.Products.Commands
{
    using ApplicationLayer.Services.Product.Commands;
    using Shouldly;
    using System.Threading;
    using UnitTests.Mocks.MockRepoSetups;
    using Xunit;

    public class ProductUpdateCommandTests : ProductUpdateRepositoryMock
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = ProductUpdateRequest.Id, Description = ProductUpdateRequest.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(true);
        }

        [Fact]
        public async void AlreadyUpToDateTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = ProductUpdateRequestUptoDate.Id, Description = ProductUpdateRequestUptoDate.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpToDate.ShouldBe(true);
            result.UpdateMessage.ShouldBe(ProductCommandMessages.UpToDate);
        }

        [Fact]
        public async void NotFoundTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(ProductRepository);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = ProductUpdateRequestNotFound.Id, Description = ProductUpdateRequestNotFound.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpdateMessage.ShouldBe(ProductCommandMessages.NotFound);
        }
    }
}
