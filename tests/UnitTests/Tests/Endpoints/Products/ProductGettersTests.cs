namespace UnitTests.Tests.Endpoints.Products
{
    using API.Controllers.Products.v1;
    using DomainLayer.Entities.Product;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Mocks;
    using Mocks.Mediator.Products;
    using Shouldly;
    using Xunit;

    public class ProductGettersTests
    {
        [Fact]
        public async void GetTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetProductsAsync();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductsGetResponse);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductsMediatorRequestsMock.ProductGetRequest.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductsGetResponse.Find(x => x.Id == ProductsMediatorRequestsMock.ProductGetRequest.Id));
        }

        [Fact]
        public async void GetByIdNotFoundTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductsMediatorRequestsMock.ProductGetRequestNotFound.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void GetPagedTest()
        {
            //Arrange
            var controller = new API.Controllers.Products.v2.ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetProductsAsync(ProductsMediatorRequestsMock.ProductsGetPaginatedRequest.PageSize, ProductsMediatorRequestsMock.ProductsGetPaginatedRequest.PageNumber);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductsGetPaginatedResponse);
        }
    }
}
