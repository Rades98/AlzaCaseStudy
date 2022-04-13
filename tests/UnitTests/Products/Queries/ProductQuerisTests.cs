namespace UnitTests.Products.Queries
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Mocks;
    using Moq;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductQuerisTests
    {
        private readonly Mock<IGenericRepository<ProductEntity>> _mockData;

        public ProductQuerisTests()
        {
            _mockData = MockProductRepository.GetProductRepository();
        }

        [Fact]
        public async void ProductsGetTest()
        {
            //Arrange
            var handler = new ProductsGetRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(MockProductRepository.ProductsGetRequest, CancellationToken.None);

            //Assert
            result.ToList().Count.ShouldBe(MockProductRepository.ProductsCount);
        }

        [Fact]
        public async void ProductsGetPaginatedTest()
        {
            //Arrange
            var handler = new ProductsGetPaginatedRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(MockProductRepository.ProductsGetPaginatedRequest, CancellationToken.None);

            //Assert
            result.ToList().Count.ShouldBe(MockProductRepository.ProductsGetPaginatedRequest.PageSize);
        }

        [Fact]
        public async void ProductGetTest()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(new ProductGetRequest() { Id = MockProductRepository.ProductGetRequest.Id }, CancellationToken.None);

            //Assert
            result.Id.ShouldBe(MockProductRepository.ProductGetRequest.Id);
        }

        [Fact]
        public async void ProductGetNotFoundTest()
        {
            //Arrange
            var handler = new ProductGetRequest.Handler(_mockData.Object);

            //Act
            var result = await handler.Handle(new ProductGetRequest() { Id = MockProductRepository.ProductGetRequestNotFound.Id }, CancellationToken.None);

            //Assert
            result.Id.ShouldBe(new System.Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
