namespace UnitTests.Products.Controller
{
    using API.Controllers.Products.v1;
    using DomainLayer.Entities.Product;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Mocks.MockMediator.ProductUpdateResponse;
    using Shouldly;
    using UnitTests.Mocks.MockMediator;
    using Xunit;

    public class ProductUpdateControllerTests : ProductUpdateResponseMock
    {
        [Fact]
        public async void UpdateTest()
        {
            //Arrange
            var controller = new ProductsController(Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductUpdateRequest.Id, ProductUpdateRequest.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductUpdateResponse);
        }

        [Fact]
        public async void UpdateTestNotFound()
        {
            //Arrange
            var controller = new ProductsController(Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductUpdateRequestNotFound.Id, ProductUpdateRequestNotFound.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductUpdateResponseNotFound);
        }

        [Fact]
        public async void UpdateTestUpToDate()
        {
            //Arrange
            var controller = new ProductsController(Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductUpdateRequestUpToDate.Id, ProductUpdateRequestUpToDate.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductUpdateResponseUpToDate);
        }
    }
}
