namespace UnitTests.Tests.Endpoints.ProductDetails
{
    using API.Controllers.ProductDetails.v1;
    using DomainLayer.Entities.Product;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Mocks;
    using Mocks.Mediator.ProductDetails;
    using Shouldly;
    using Xunit;

    public class ProductDetailGettersTests
    {
        [Fact]
        public async void GetTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetProductsAsync();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductsGetResponse);
        }

        [Fact]
        public async void GetByIdTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductDetailsMediatorRequestsMock.ProductGetRequest.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductsGetResponse.Find(x => x.Id == ProductDetailsMediatorRequestsMock.ProductGetRequest.Id));
        }

        [Fact]
        public async void GetByIdNotFoundTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetByIdAsync(ProductDetailsMediatorRequestsMock.ProductGetRequestNotFound.Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void GetPagedTest()
        {
            //Arrange
            var controller = new API.Controllers.ProductDetails.v2.ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.GetProductsAsync(ProductDetailsMediatorRequestsMock.ProductsGetPaginatedRequest.PageSize, ProductDetailsMediatorRequestsMock.ProductsGetPaginatedRequest.PageNumber);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductsGetPaginatedResponse);
        }
    }
}
