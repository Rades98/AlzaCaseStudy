namespace UnitTests.Mocks.MockMediator.ProductUpdateResponse
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using MediatR;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ProductUpdateResponseMock
    {
        public static IMediator Mediator => GetMediator().Object;

        private static Mock<IMediator> GetMediator()
        {

            var mockMediator = new Mock<IMediator>();

            var response = new List<ProductGetResponse>
            {
                new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductUpdateRequestUpToDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductUpdateRequestUpToDate.Description }
            };

            mockMediator.Setup(m => m.Send(ProductsGetRequest, CancellationToken.None)).ReturnsAsync(response);
            mockMediator.Setup(m => m.Send(ProductUpdateRequest, CancellationToken.None)).ReturnsAsync(ProductUpdateResponse);
            mockMediator.Setup(m => m.Send(ProductUpdateRequestNotFound, CancellationToken.None)).ReturnsAsync(ProductUpdateResponseNotFound);

            return mockMediator;
        }

        #region ProductUpdate

        private static readonly string _productUpdateDescription = "New cool description";

        public static ProductsGetRequest ProductsGetRequest => new()
        {
            OrderBy = p => p.Name
        };

        public static ProductUpdateResponse ProductUpdateResponse => new()
        {
            Updated = true,
            UpToDate = true,
            UpdateMessage = _productUpdateDescription
        };

        public static ProductUpdateRequest ProductUpdateRequest => new()
        {
            Description = _productUpdateDescription,
            Id = new Guid(),
        };

        #endregion

        #region ProductUpdateNotFound

        private static readonly string _productUpdateDescriptionNotFound = "Product not found";

        public static ProductUpdateResponse ProductUpdateResponseNotFound => new()
        {
            Updated = false,
            UpToDate = false,
            UpdateMessage = _productUpdateDescriptionNotFound
        };

        public static ProductUpdateRequest ProductUpdateRequestNotFound => new()
        {
            Description = _productUpdateDescription,
            Id = new Guid(),
        };

        #endregion

        #region ProductUpdateUpToDate

        public static ProductsGetRequest ProductsGetRequestUpToDate => new()
        {
            OrderBy = p => p.Name
        };

        public static ProductUpdateResponse ProductUpdateResponseUpToDate => new()
        {
            Updated = false,
            UpToDate = true,
            UpdateMessage = "Product is up to date"
        };

        public static ProductUpdateRequest ProductUpdateRequestUpToDate => new()
        {
            Description = "Smth lol",
            Id = new Guid(),
        };

        #endregion
    }
}
