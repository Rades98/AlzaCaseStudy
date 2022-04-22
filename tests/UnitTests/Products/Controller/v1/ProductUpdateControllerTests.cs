namespace UnitTests.Products.Controller.v1
{
    using API.Controllers.v1;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Moq;
    using Shouldly;
    using Mocks.MockMediator.ProductUpdateResponse;
    using Xunit;

    public class ProductUpdateControllerTests : ProductUpdateResponseMock
    {
        private readonly IMemoryCache _memoryCache = new Mock<IMemoryCache>().Object;

        [Fact]
        public async void UpdateTest()
        {
            //Arrange
            var controller = new ProductsController(Mediator);

            //Act
            var actionResult = await controller.Update(ProductUpdateRequest.Id, ProductUpdateRequest.Description);

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
            var controller = new ProductsController(Mediator);

            //Act
            var actionResult = await controller.Update(ProductUpdateRequestNotFound.Id, ProductUpdateRequestNotFound.Description);

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
            var controller = new ProductsController(Mediator);

            //Act
            var actionResult = await controller.Update(ProductUpdateRequestUpToDate.Id, ProductUpdateRequestUpToDate.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductUpdateResponseUpToDate);
        }
    }
}
