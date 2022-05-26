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

    public class ProductUpdateTests
    {
        [Fact]
        public async void UpdateTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductsMediatorRequestsMock.ProductUpdateRequest.Id, ProductsMediatorRequestsMock.ProductUpdateRequest.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductUpdateResponse);
        }

        [Fact]
        public async void UpdateNotFoundTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductsMediatorRequestsMock.ProductUpdateRequestNotFound.Id, ProductsMediatorRequestsMock.ProductUpdateRequestNotFound.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductUpdateResponseNotFound);
        }

        [Fact]
        public async void UpdateUpToDateTest()
        {
            //Arrange
            var controller = new ProductsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductsMediatorRequestsMock.ProductUpdateRequestUpToDate.Id, ProductsMediatorRequestsMock.ProductUpdateRequestUpToDate.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductsMediatorResponsesMock.ProductUpdateResponseUpToDate);
        }
    }
}
