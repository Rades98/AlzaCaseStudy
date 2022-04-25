namespace UnitTests.Mocks.MockMediator.ProductGetResponse
{
    using ApplicationLayer.Services.Product.Queries;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using MediatR;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using X.PagedList;

    public abstract class ProductGetResponseRequestMock
    {
        private static readonly List<ProductGetResponse> _responses = new()
        {
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
        };

        public static List<ProductGetResponse> Response => _responses;
        public static IMediator Mediator => GetMediator().Object;

        public static Mock<IMediator> MediatorMock => GetMediator();

        public static ProductsGetRequest ProductsGetRequest => new()
        {
            OrderBy = p => p.Name
        };

        public static ProductGetRequest ProductGetRequest => new()
        {
            Id = Guid.NewGuid()
        };

        public static ProductGetRequest ProductGetRequestNotFound => new()
        {
            Id = Guid.NewGuid()
        };

        public static ProductsGetPaginatedRequest ProductsGetPaginatedRequest => new()
        {
            OrderBy = p => p.Name,
            OrderByDesc = false,
            PageNumber = 2,
            PageSize = 4,
        };

        public static List<ProductGetResponse> ProductsGetPaginatedResponse =>
            _responses
                .OrderBy(o => o.Name)
                .ToPagedList(ProductsGetPaginatedRequest.PageNumber, ProductsGetPaginatedRequest.PageSize)
                .ToList();

        private static Mock<IMediator> GetMediator()
        {

            var mockMediator = new Mock<IMediator>();
            _responses.Add(new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" });

            mockMediator.Setup(m => m.Send(ProductsGetRequest, CancellationToken.None)).ReturnsAsync(_responses);
            mockMediator.Setup(m => m.Send(ProductsGetPaginatedRequest, CancellationToken.None))
                .ReturnsAsync(ProductsGetPaginatedResponse);

            return mockMediator;
        }
    }
}
