namespace UnitTests.Mocks.MockRepoSetups
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;
    using System.Threading;

    public class ProductGetRepositoryMock : ProductRepositoryBaseMock
    {
        public static IGenericRepository<ProductEntity> ProductRepository => GetProductRepository().Object;

        public readonly static ProductGetRequest ProductGetRequest = new()
        {
            Id = Guid.NewGuid(),
        };

        public readonly static ProductGetRequest ProductGetRequestNotFound = new()
        {
            Id = Guid.NewGuid(),
        };

        private static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);

            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            var products = Products;
            //Add specific case for testing
            products.Add(new ProductEntity() { Name = "test item", Created = created, Price = 0, Id = ProductGetRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" });

            #region Mock repo setups

            mockRepo.Setup(repo => repo.GetAsync(ProductGetRequest.Id, CancellationToken.None)).ReturnsAsync(products.Find(x => x.Id == ProductGetRequest.Id));

            #endregion

            return mockRepo;
        }
    }
}
