namespace UnitTests.Mocks
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Commands;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using X.PagedList;

    public static class MockProductRepository
    {
        private static List<ProductEntity> _products = new List<ProductEntity>();

        public static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

            _products = new List<ProductEntity>
            {
                new ProductEntity() { Name = "test item 1", Created = created, Price = 0, Id = new Guid("3b05b497-1f1b-487f-bf71-0084d51604d4"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 2", Created = created, Price = 0, Id = new Guid("f1d516c1-069c-4d93-ba22-14ae1785891e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 3", Created = created, Price = 0, Id = new Guid("2b9e68c4-8f8e-43b3-9755-b892dcbeaeba"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 4", Created = created, Price = 0, Id = new Guid("f6225d98-0f14-4dce-8543-5811b6049f9b"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 5", Created = created, Price = 0, Id = new Guid("e4b116e0-d018-4cb0-90e0-c5b9ef17f4e2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 6", Created = created, Price = 0, Id = new Guid("392f47fc-ad49-4d7e-b43a-21388c63c86f"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 7", Created = created, Price = 0, Id = new Guid("3d2c2880-8ebe-4c36-933c-3d4435a28ede"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 8", Created = created, Price = 0, Id = new Guid("5c400b7c-6ac4-47b9-9f78-417349f953a9"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 9", Created = created, Price = 0, Id = ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 10", Created = created, Price = 0, Id = new Guid("26e017fc-0626-4540-9691-11bfcc15d5a3"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 11", Created = created, Price = 0, Id = new Guid("ac2538e6-90c0-40c5-bdb0-bf991b84ef66"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 12", Created = created, Price = 0, Id = ProductUpdateRequestUptoDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductUpdateRequestUptoDate.Description },
                new ProductEntity() { Name = "test item 13", Created = created, Price = 0, Id = new Guid("cab02fb2-81e8-45d3-8bcf-d8787fa028da"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 14", Created = created, Price = 0, Id = new Guid("1751d157-33dd-438c-92f4-00f5f9b1d066"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 15", Created = created, Price = 0, Id = new Guid("d6d32626-5d4d-4bd0-82ac-723e48f4bc1c"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 16", Created = created, Price = 0, Id = new Guid("162d4fd2-a3f7-441c-a3b0-9c6fcb9f4eb2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 18", Created = created, Price = 0, Id = ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 17", Created = created, Price = 0, Id = new Guid("fed2db27-f1b7-43b6-a5df-6e6d43eb22ac"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 19", Created = created, Price = 0, Id = new Guid("6bc496f5-a270-49ad-90ee-f00b3243053e"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
                new ProductEntity() { Name = "test item 20", Created = created, Price = 0, Id = new Guid("baf7b04a-0424-407b-a4f3-d4ae38b3d5d2"), ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" },
            };

            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            #region Mock repo setups

            mockRepo.Setup(repo => repo.GetAll(
                ProductsGetRequest.OrderByDesc, ProductsGetRequest.OrderBy
                ))
                .ReturnsAsync(_products
                    .ToList()
                    .OrderBy(ProductsGetRequest.OrderBy)
                    .ToList());

            mockRepo.Setup(repo => repo.GetAllPaginated(
                ProductsGetPaginatedRequest.PageNumber,
                ProductsGetPaginatedRequest.PageSize,
                ProductsGetPaginatedRequest.OrderByDesc,
                ProductsGetPaginatedRequest.OrderBy
                ))
                .ReturnsAsync
                (_products
                    .ToList()
                    .OrderBy(ProductsGetPaginatedRequest.OrderBy)
                    .ToPagedList(ProductsGetPaginatedRequest.PageNumber, ProductsGetPaginatedRequest.PageSize));

            mockRepo.Setup(repo => repo.Get(ProductGetRequest.Id)).ReturnsAsync(_products.Find(x => x.Id == ProductGetRequest.Id));

            mockRepo.Setup(repo => repo.Get(ProductUpdateRequest.Id)).ReturnsAsync(_products.Find(x => x.Id == ProductUpdateRequest.Id));

            mockRepo.Setup(repo => repo.Get(ProductUpdateRequestUptoDate.Id)).ReturnsAsync(_products.Find(x => x.Id == ProductUpdateRequestUptoDate.Id));

            #endregion

            return mockRepo;
        }

        public static int ProductsCount => _products.Count;

        #region Requests

        public static ProductsGetPaginatedRequest ProductsGetPaginatedRequest => new ProductsGetPaginatedRequest
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
            PageNumber = 1,
            PageSize = 10
        };

        public static ProductsGetRequest ProductsGetRequest => new ProductsGetRequest
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        public static ProductGetRequest ProductGetRequest => new ProductGetRequest
        {
            Id = new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"),
        };

        public static ProductGetRequest ProductGetRequestNotFound => new ProductGetRequest
        {
            Id = new Guid("7167A0A8-4795-44DD-AB96-EB507C6AEF5A"),
        };

        public static ProductUpdateRequest ProductUpdateRequest => new ProductUpdateRequest
        {
            Id = new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"),
            Description = "Some awesome new description"
        };

        public static ProductUpdateRequest ProductUpdateRequestUptoDate => new ProductUpdateRequest
        {
            Id = new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"),
            Description = "Some awesome new description"
        };

        public static ProductUpdateRequest ProductUpdateRequestNotFound => new ProductUpdateRequest
        {
            Id = new Guid("7167A0A8-4795-44DD-AB96-EB507C6AEF5A"),
            Description = "Some awesome new description"
        };

        #endregion
    }
}
