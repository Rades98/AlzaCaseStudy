namespace UnitTests.Tests.Mediator.ProductDetails.Queries
{
    using ApplicationLayer.Services.ProductDetails.Queries.Requests;
    using Mocks;
    using Mocks.GenericRepo.ProductDetails;
    using Shouldly;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ProductDetailsGetPaginatedTests
    {
        [Fact]
        public async void Test()
        {
            //Arrange
            var handler = new ProductDetailsGetPaginatedRequest.Handler(MockProvider<ProductDetailGetRequest>.ProductRepository);

            //Act
            var result = await handler.Handle(ProductDetailsRepositoryRequestsMock.ProductsGetPaginatedRequest, CancellationToken.None);

            //Assert
            result!.ToList().Count.ShouldBe(ProductDetailsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageSize);
        }
    }
}
