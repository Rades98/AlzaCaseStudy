namespace UnitTests.Products.Controller
{
    using API.Controllers.Products.v1;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Shouldly;
    using UnitTests.Mocks.MockMediator;
    using UnitTests.Mocks.MockMediator.ProductGetResponse;
    using Xunit;

    public class ProductGettersControllerTests : ProductGetResponseRequestMock
    {
        [Fact]
        public async void GetTest()
        {
            //Arrange
            var controller = new ProductsController(Mediator, ActionDescriptorCollectionProviderMock.ADCP);

            //Act
            var actionResult = await controller.GetProductsAsync();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(Response);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //Arrange
            var controller = new ProductsController(Mediator, ActionDescriptorCollectionProviderMock.ADCP);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductGetRequest.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(Response.Find(x => x.Id == ProductGetRequest.Id));
        }

        [Fact]
        public async void GetByIdNotFoundTest()
        {
            //Arrange
            var controller = new ProductsController(Mediator, ActionDescriptorCollectionProviderMock.ADCP);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductGetRequestNotFound.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void GetPagedTest()
        {
            //Arrange
            var controller = new API.Controllers.Products.v2.ProductsController(Mediator, ActionDescriptorCollectionProviderMock.ADCP);

            //Act
            var actionResult = await controller.GetProductsAsync(ProductsGetPaginatedRequest.PageSize, ProductsGetPaginatedRequest.PageNumber);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductsGetPaginatedResponse);
        }
    }
}
