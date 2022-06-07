namespace UnitTests.Mocks.Mediator.ProductDetails
{
    using ApplicationLayer.Services.ProductDetails.Commands;
    using ApplicationLayer.Services.ProductDetails.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using X.PagedList;

    public class ProductDetailsMediatorResponsesMock
    {
        public static readonly ProductDetailUpdateResponse ProductUpdateResponseUpToDate = new()
        {
            Updated = false,
            UpToDate = true,
            UpdateMessage = "Product is up to date"
        };

        public static readonly ProductDetailUpdateResponse ProductUpdateResponseNotFound = new()
        {
            Updated = false,
            UpToDate = false,
            UpdateMessage = "Product not found"
        };

        public static readonly ProductDetailUpdateResponse ProductUpdateResponse = new()
        {
            Updated = true,
            UpToDate = true,
            UpdateMessage = ProductDetailsMediatorRequestsMock.ProductUpdateDescription
        };

        public static readonly List<ProductDetailGetResponse> ProductsGetPaginatedResponse =
            ProductsGetResponse
                .OrderBy(o => o.Name)
                .ToPagedList(ProductDetailsMediatorRequestsMock.ProductsGetPaginatedRequest.PageNumber, ProductDetailsMediatorRequestsMock.ProductsGetPaginatedRequest.PageSize)
                .ToList();

        public static List<ProductDetailGetResponse> ProductsGetResponse => GetResponses();

        private static List<ProductDetailGetResponse> GetResponses()
        {
            return new List<ProductDetailGetResponse>() {
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special get cases
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductDetailsMediatorRequestsMock.ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special update cases
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductDetailsMediatorRequestsMock.ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductDetailGetResponse() { Name = "test item", Created = DateTime.Now, Price = 0, Id = ProductDetailsMediatorRequestsMock.ProductUpdateRequestUpToDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductDetailsMediatorRequestsMock.ProductUpdateRequestUpToDate.Description }
            };
        }
    }
}
