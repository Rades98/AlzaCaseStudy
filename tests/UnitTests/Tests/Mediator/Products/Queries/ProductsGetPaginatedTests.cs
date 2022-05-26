namespace UnitTests.Tests.Mediator.Products.Queries
{
    using ApplicationLayer.Services.Product.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.Products;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductsGetPaginatedTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductsGetPaginatedRequest.Handler(MockProvider<ProductGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest, CancellationToken.None);

            //Assert
            result!.ToList().Count.ShouldBe(ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageSize);
        }
    }
}
