namespace UnitTests.Mocks.MockRepoSetups
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;

    public class ProductGetRepositoryMock : ProductRepositoryBaseMock
    {
        public static IGenericRepository<ProductEntity> ProductRepository => GetProductRepository().Object;

        public static ProductGetRequest ProductGetRequest => new()
        {
            Id = new Guid("3054191e-0b54-436d-9e85-4ac7f8ef1277"),
        };

        public static ProductGetRequest ProductGetRequestNotFound => new()
        {
            Id = new Guid("7167A0A8-4795-44DD-AB96-EB507C6AEF5A"),
        };

        private static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            var products = Products;
            //Add specific case for testing
            products.Add(new ProductEntity() { Name = "test item", Created = created, Price = 0, Id = ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" });

            #region Mock repo setups

            mockRepo.Setup(repo => repo.Get(ProductGetRequest.Id)).ReturnsAsync(products.Find(x => x.Id == ProductGetRequest.Id));

            #endregion

            return mockRepo;
        }
    }
}
