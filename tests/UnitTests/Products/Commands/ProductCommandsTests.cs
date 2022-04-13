namespace UnitTests.Products.Commands
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Commands;
    using DomainLayer.Entities.Product;
    using Mocks;
    using Moq;
    using Shouldly;
    using System.Threading;
    using Xunit;

    public class ProductCommandsTests
    {
        private readonly Mock<IGenericRepository<ProductEntity>> _mockData;

        public ProductCommandsTests()
        {
            _mockData = MockProductRepository.GetProductRepository();
        }

        [Fact]
        public async void ProductUpdateTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = MockProductRepository.ProductUpdateRequest.Id, Description = MockProductRepository.ProductUpdateRequest.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(true);
        }

        [Fact]
        public async void ProductUpdateAlreadyUpToDateTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = MockProductRepository.ProductUpdateRequestUptoDate.Id, Description = MockProductRepository.ProductUpdateRequestUptoDate.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpdateMessage.ShouldBe(CommandMessages.UpToDate);
        }

        [Fact]
        public async void ProductUpdateNotFoundTest()
        {
            //Arrange
            var handler = new ProductUpdateRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(new ProductUpdateRequest() { Id = MockProductRepository.ProductUpdateRequestNotFound.Id, Description = MockProductRepository.ProductUpdateRequestNotFound.Description }, CancellationToken.None);

            //Assert
            result.Updated.ShouldBe(false);
            result.UpdateMessage.ShouldBe(CommandMessages.NotFound);
        }
    }
}
