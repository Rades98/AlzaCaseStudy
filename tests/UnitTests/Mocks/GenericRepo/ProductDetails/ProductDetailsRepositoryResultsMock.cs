namespace UnitTests.Mocks.GenericRepo.ProductDetails
{
    using DomainLayer.Entities.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using X.PagedList;

    public static class ProductDetailsRepositoryResultsMock
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

        public static readonly List<ProductDetailEntity> Products = GetResponses();

        public static readonly List<ProductDetailEntity> GetAllResponse = Products
                     .OrderBy(ProductDetailsRepositoryRequestsMock.ProductsGetRequest.OrderBy)
                     .ToList();

        public static readonly IPagedList<ProductDetailEntity> GetAllPaginatedResponse = Products
                    .OrderBy(ProductDetailsRepositoryRequestsMock.ProductsGetPaginatedRequest.OrderBy)
                    .ToPagedList(ProductDetailsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageNumber, ProductDetailsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageSize);

        private static List<ProductDetailEntity> GetResponses()
        {
            return new() {
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special GET cases
                new() { Name = "test item", Created = _created, Price = 0, Id = ProductDetailsRepositoryRequestsMock.ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special Update cases
                new() { Name = "test item", Created = _created, Price = 0, Id = ProductDetailsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductDetailsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Description },
                new() { Name = "test item", Created = _created, Price = 0, Id = ProductDetailsRepositoryRequestsMock.ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" }

            };
        }
    }
}
