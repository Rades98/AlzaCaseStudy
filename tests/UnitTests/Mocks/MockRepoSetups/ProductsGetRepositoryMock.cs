namespace UnitTests.Mocks.MockRepoSetups
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsGetRepositoryMock : ProductRepositoryBaseMock
    {
        private static int _productsCount = 0;
        public static int ProductsCount => _productsCount;

        public static IGenericRepository<ProductEntity> ProductRepository => GetProductRepository().Object;

        public static ProductsGetRequest ProductsGetRequest => new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        public static ProductsGetRequest ProductsGetRequestWhenNone => new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
        };

        private static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);
            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            var products = Products;

            _productsCount = products.Count;

            #region Mock repo setups

            mockRepo.Setup(repo => repo.GetAll(
                 ProductsGetRequest.OrderByDesc, ProductsGetRequest.OrderBy
                 ))
                 .ReturnsAsync(products
                     .ToList()
                     .OrderBy(ProductsGetRequest.OrderBy)
                     .ToList());

            mockRepo.Setup(repo => repo.GetAll(
                ProductsGetRequestWhenNone.OrderByDesc, ProductsGetRequestWhenNone.OrderBy
                ))
                .ReturnsAsync(new List<ProductEntity>());

            #endregion

            return mockRepo;
        }
    }
}
