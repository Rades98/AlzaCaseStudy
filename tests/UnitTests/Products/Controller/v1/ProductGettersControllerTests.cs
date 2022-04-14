namespace UnitTests.Products.Controller.v1
{
    using API.Controllers.v1;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Moq;
    using Shouldly;
    using UnitTests.Mocks.MockMediator.ProductGetResponse;
    using Xunit;

    public class ProductGettersControllerTests : ProductGetResponseRequestMock
    {
        private readonly IMemoryCache _memoryCache = new Mock<IMemoryCache>().Object;

        [Fact]
        public async void GetTest()
        {
            //Arrange
            var controller = new ProductController(_memoryCache, Mediator);

            //Act
            var actionResult = await controller.GetProducts();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(Response);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //Arrange
            var controller = new ProductController(_memoryCache, Mediator);

            //Act
            var actionResult = await controller.GetById(ProductGetRequest.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(Response.Find(x => x.Id == ProductGetRequest.Id));
        }

        [Fact]
        public async void GetByIdNotFoundTest()
        {
            //Arrange
            var controller = new ProductController(_memoryCache, Mediator);

            //Act
            var actionResult = await controller.GetById(ProductGetRequestNotFound.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void GetPagedTest()
        {
            //Arrange
            var controller = new API.Controllers.v2.ProductController(_memoryCache, Mediator);

            //Act
            var actionResult = await controller.GetProducts(ProductsGetPaginatedRequest.PageSize, ProductsGetPaginatedRequest.PageNumber);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductsGetPaginatedResponse);
        }
    }
}
