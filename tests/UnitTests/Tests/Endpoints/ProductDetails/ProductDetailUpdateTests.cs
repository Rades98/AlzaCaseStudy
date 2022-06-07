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

    public class ProductDetailUpdateTests
    {
        [Fact]
        public async void UpdateTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductDetailsMediatorRequestsMock.ProductUpdateRequest.Id, ProductDetailsMediatorRequestsMock.ProductUpdateRequest.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductUpdateResponse);
        }

        [Fact]
        public async void UpdateNotFoundTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductDetailsMediatorRequestsMock.ProductUpdateRequestNotFound.Id, ProductDetailsMediatorRequestsMock.ProductUpdateRequestNotFound.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductUpdateResponseNotFound);
        }

        [Fact]
        public async void UpdateUpToDateTest()
        {
            //Arrange
            var controller = new ProductDetailsController(MockProvider<ProductEntity>.Mediator, MockProvider<ProductEntity>.ADCP, MockProvider<ProductEntity>.Logger);

            //Act
            var actionResult = await controller.UpdateAsync(ProductDetailsMediatorRequestsMock.ProductUpdateRequestUpToDate.Id, ProductDetailsMediatorRequestsMock.ProductUpdateRequestUpToDate.Description);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            result?.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result?.Value.ShouldNotBeNull();
            result?.Value.ShouldBe(ProductDetailsMediatorResponsesMock.ProductUpdateResponseUpToDate);
        }
    }
}
