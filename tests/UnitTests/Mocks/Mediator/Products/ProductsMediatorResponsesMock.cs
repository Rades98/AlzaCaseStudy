namespace UnitTests.Mocks.Mediator.Products
{
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using X.PagedList;

    public class ProductsMediatorResponsesMock
    {
        public static readonly ProductUpdateResponse ProductUpdateResponseUpToDate = new()
        {
            Updated = false,
            UpToDate = true,
            UpdateMessage = "Product is up to date"
        };

        public static readonly ProductUpdateResponse ProductUpdateResponseNotFound = new()
        {
            Updated = false,
            UpToDate = false,
            UpdateMessage = "Product not found"
        };

        public static readonly ProductUpdateResponse ProductUpdateResponse = new()
        {
            Updated = true,
            UpToDate = true,
            UpdateMessage = ProductsMediatorRequestsMock.ProductUpdateDescription
        };

        public static readonly List<ProductGetResponse> ProductsGetPaginatedResponse =
            ProductsGetResponse
                .OrderBy(o => o.Name)
                .ToPagedList(ProductsMediatorRequestsMock.ProductsGetPaginatedRequest.PageNumber, ProductsMediatorRequestsMock.ProductsGetPaginatedRequest.PageSize)
                .ToList();

        public static List<ProductGetResponse> ProductsGetResponse => GetResponses();

        private static List<ProductGetResponse> GetResponses()
        {
            return new List<ProductGetResponse>() {
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

                //Special get cases
                new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductsMediatorRequestsMock.ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special update cases
                new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductsMediatorRequestsMock.ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductsMediatorRequestsMock.ProductUpdateRequestUpToDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductsMediatorRequestsMock.ProductUpdateRequestUpToDate.Description }
            };
        }
    }
}
