namespace UnitTests.Mocks.GenericRepo.Products
{
    using DomainLayer.Entities.Product;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using X.PagedList;

    public static class ProductsRepositoryResultsMock
    {
        private static readonly DateTime _created = new(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

        public static readonly List<ProductEntity> Products = GetResponses();

        public static readonly List<ProductEntity> GetAllResponse = Products
                     .OrderBy(ProductsRepositoryRequestsMock.ProductsGetRequest.OrderBy)
                     .ToList();

        public static readonly IPagedList<ProductEntity> GetAllPaginatedResponse = Products
                    .OrderBy(ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.OrderBy)
                    .ToPagedList(ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageNumber, ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageSize);

        private static List<ProductEntity> GetResponses()
        {
            return new() {
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = Guid.NewGuid(), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special GET cases
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = ProductsRepositoryRequestsMock.ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },

                //Special Update cases
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = ProductsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Description },
                new ProductEntity() { Name = "test item", Created = _created, Price = 0, Id = ProductsRepositoryRequestsMock.ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" }

            };
        }
    }
}
