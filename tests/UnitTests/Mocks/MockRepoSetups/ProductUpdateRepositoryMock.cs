namespace UnitTests.Mocks.MockRepoSetups
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Commands;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;
    using System.Threading;

    public class ProductUpdateRepositoryMock : ProductRepositoryBaseMock
    {
        public static IGenericRepository<ProductEntity> ProductRepository => GetProductRepository().Object;

        public static ProductUpdateRequest ProductUpdateRequest => new()
        {
            Id = new Guid("c8a55f25-dbf7-41a4-87a9-4766f87e45d3"),
            Description = "Some awesome new description"
        };

        public static ProductUpdateRequest ProductUpdateRequestUptoDate => new()
        {
            Id = new Guid("587392f1-ed02-471c-b97d-475ca66e5a4f"),
            Description = "Some awesome new description"
        };

        public static ProductUpdateRequest ProductUpdateRequestNotFound => new()
        {
            Id = new Guid("7167A0A8-4795-44DD-AB96-EB507C6AEF5A"),
            Description = "Some awesome new description"
        };

        private static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);
            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            var products = Products;
            //Add specific case for testing
            products.Add(new ProductEntity() { Name = "test item", Created = created, Price = 0, Id = ProductUpdateRequestUptoDate.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = ProductUpdateRequestUptoDate.Description });
            products.Add(new ProductEntity() { Name = "test item", Created = created, Price = 0, Id = ProductUpdateRequest.Id, ImgUri = new Uri("http://www.pagination.xx/pag"), Description = "Test data" });

            #region Mock repo setups

            mockRepo.Setup(repo => repo.GetAsync(ProductUpdateRequest.Id, CancellationToken.None)).ReturnsAsync(products.Find(x => x.Id == ProductUpdateRequest.Id));

            mockRepo.Setup(repo => repo.GetAsync(ProductUpdateRequestUptoDate.Id, CancellationToken.None)).ReturnsAsync(products.Find(x => x.Id == ProductUpdateRequestUptoDate.Id));

            #endregion

            return mockRepo;
        }
    }
}
