namespace UnitTests.Mocks.MockRepoSetups
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Product.Queries.Requests;
    using DomainLayer.Entities.Product;
    using Moq;
    using System;
    using System.Linq;
    using System.Threading;
    using X.PagedList;

    public class ProductsGetPaginatedRepositoryMock : ProductRepositoryBaseMock
    {
        public static IGenericRepository<ProductEntity> ProductRepository => GetProductRepository().Object;

        public static ProductsGetPaginatedRequest ProductsGetPaginatedRequest => new()
        {
            OrderBy = o => o.Name,
            OrderByDesc = false, //Use false, or change orderby clause in Setup to OrderbyDesc
            PageNumber = 1,
            PageSize = 10
        };

        private static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
        {
            var created = new DateTime(2022, 4, 12, 17, 00, 00, 222, DateTimeKind.Local);
            var mockRepo = new Mock<IGenericRepository<ProductEntity>>();

            var products = Products;

            #region Mock repo setups

            mockRepo.Setup(repo => repo.GetAllPaginatedAsync(
                ProductsGetPaginatedRequest.PageNumber,
                ProductsGetPaginatedRequest.PageSize,
                ProductsGetPaginatedRequest.OrderByDesc,
                ProductsGetPaginatedRequest.OrderBy, 
                CancellationToken.None
                ))
                .ReturnsAsync
                (products
                    .ToList()
                    .OrderBy(ProductsGetPaginatedRequest.OrderBy)
                    .ToPagedList(ProductsGetPaginatedRequest.PageNumber, ProductsGetPaginatedRequest.PageSize));

            #endregion

            return mockRepo;
        }
    }
}
