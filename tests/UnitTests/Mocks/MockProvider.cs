namespace UnitTests.Mocks
{
    using ApplicationLayer.Interfaces;
    using ApplicationLayer.Services.Users.Commands.Login;
    using DomainLayer.Entities.Product;
    using DomainLayer.Entities.Users;
    using GenericRepo.Products;
    using GenericRepo.Users;
    using GenericRepo.Users.UserRoleRelations;
    using GenericRepo.Users.UserRoles;
    using Mediator.Products;
    using Mediator.Users;
    using MediatR;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;

    public static class MockProvider<T> where T : class
    {
        public static readonly IActionDescriptorCollectionProvider ADCP = GetADCP();

        public static readonly ILogger<T> Logger = GetLogger();

        public static readonly IConfiguration Configuration = GetConfiguration();

        public static readonly IMediator Mediator = GetMediator().Object;

        public static readonly IGenericRepository<ProductDetailEntity> ProductRepository = GetProductRepository();

        public static readonly IGenericRepository<UserEntity> UserRepository = GetUserRepository();
        public static readonly IGenericRepository<UserEntity> UserRepository_NoUsr = GetUserRepository_NoUsr();
        public static readonly IGenericRepository<UserRoleEntity> UserRoleRepository = GetUserRoleRepository();
        public static readonly IGenericRepository<UserRoleRelationEntity> UserRoleRelationRepository = GetUserRoleRelationRepository();

        #region Mediator

        private static Mock<IMediator> GetMediator()
        {
            var mockMediator = new Mock<IMediator>();

            mockMediator.Setup(m => m.Send(ProductsMediatorRequestsMock.ProductsGetRequest, CancellationToken.None))
                .ReturnsAsync(ProductsMediatorResponsesMock.ProductsGetResponse);
            mockMediator.Setup(m => m.Send(ProductsMediatorRequestsMock.ProductsGetPaginatedRequest, CancellationToken.None))
                .ReturnsAsync(ProductsMediatorResponsesMock.ProductsGetPaginatedResponse);

            mockMediator.Setup(m => m.Send(ProductsMediatorRequestsMock.ProductUpdateRequest, CancellationToken.None))
                .ReturnsAsync(ProductsMediatorResponsesMock.ProductUpdateResponse);
            mockMediator.Setup(m => m.Send(ProductsMediatorRequestsMock.ProductUpdateRequestNotFound, CancellationToken.None))
                .ReturnsAsync(ProductsMediatorResponsesMock.ProductUpdateResponseNotFound);

            mockMediator.Setup(m => m.Send(It.IsAny<UserLoginRequest>(), CancellationToken.None))
                .ReturnsAsync(UsersMediatorResponsesMock.UserLoginResponse);

            return mockMediator;
        }

        #endregion

        #region Product repo

        private static IGenericRepository<ProductDetailEntity> GetProductRepository()
        {
            var mockRepo = new Mock<IGenericRepository<ProductDetailEntity>>();

            mockRepo.Setup(repo => repo.GetAsync(ProductsRepositoryRequestsMock.ProductGetRequest.Id, CancellationToken.None))
                .ReturnsAsync(ProductsRepositoryResultsMock.Products.Find(x => x.Id == ProductsRepositoryRequestsMock.ProductGetRequest.Id));

            mockRepo.Setup(repo => repo.GetAsync(ProductsRepositoryRequestsMock.ProductUpdateRequest.Id, CancellationToken.None))
                .ReturnsAsync(ProductsRepositoryResultsMock.Products.Find(x => x.Id == ProductsRepositoryRequestsMock.ProductUpdateRequest.Id));

            mockRepo.Setup(repo => repo.GetAsync(ProductsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Id, CancellationToken.None))
                .ReturnsAsync(ProductsRepositoryResultsMock.Products.Find(x => x.Id == ProductsRepositoryRequestsMock.ProductUpdateRequestUptoDate.Id));

            mockRepo.Setup(repo => repo.GetAllPaginatedAsync(
                ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageNumber,
                ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.PageSize,
                ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.OrderByDesc,
                ProductsRepositoryRequestsMock.ProductsGetPaginatedRequest.OrderBy,
                CancellationToken.None
                ))
                .ReturnsAsync
                (ProductsRepositoryResultsMock.GetAllPaginatedResponse);

            mockRepo.Setup(repo => repo.GetAllAsync(
                ProductsRepositoryRequestsMock.ProductsGetRequest.OrderByDesc,
                ProductsRepositoryRequestsMock.ProductsGetRequest.OrderBy,
                CancellationToken.None
                 ))
                 .ReturnsAsync(ProductsRepositoryResultsMock.GetAllResponse);

            mockRepo.Setup(repo => repo.GetAllAsync(
                ProductsRepositoryRequestsMock.ProductsGetRequestWhenNone.OrderByDesc,
                ProductsRepositoryRequestsMock.ProductsGetRequestWhenNone.OrderBy,
                CancellationToken.None
                ))
                .ReturnsAsync(new List<ProductDetailEntity>());

            return mockRepo.Object;
        }

        #endregion

        #region User repos

        private static IGenericRepository<UserEntity> GetUserRepository()
        {
            var mockRepo = new Mock<IGenericRepository<UserEntity>>();

            mockRepo.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(UsersRepositoryResultsMock.TestUser);

            return mockRepo.Object;
        }

        private static IGenericRepository<UserEntity> GetUserRepository_NoUsr()
        {
            var mockRepo = new Mock<IGenericRepository<UserEntity>>();
            return mockRepo.Object;
        }

        private static IGenericRepository<UserRoleEntity> GetUserRoleRepository()
        {
            var mockRepo = new Mock<IGenericRepository<UserRoleEntity>>();

            mockRepo.Setup(repo => repo.GetAllWhereAsync(It.IsAny<Func<UserRoleEntity, bool>>(), CancellationToken.None))
                .ReturnsAsync(UserRoleResultsMock.Roles);

            return mockRepo.Object;
        }

        private static IGenericRepository<UserRoleRelationEntity> GetUserRoleRelationRepository()
        {
            var mockRepo = new Mock<IGenericRepository<UserRoleRelationEntity>>();

            mockRepo.Setup(repo => repo.GetAllWhereAsync(It.IsAny<Func<UserRoleRelationEntity, bool>>(), CancellationToken.None))
                .ReturnsAsync(UserRoleRelationsResultsMock.RoleRelations);

            return mockRepo.Object;
        }

        #endregion

        #region Controller dependencies

        private static IActionDescriptorCollectionProvider GetADCP()
        {
            var actionDescriptorCollectionProviderMock = new Mock<IActionDescriptorCollectionProvider>();

            actionDescriptorCollectionProviderMock.Setup(m => m.ActionDescriptors).Returns(new ActionDescriptorCollection(new List<ActionDescriptor>(), 0));

            return actionDescriptorCollectionProviderMock.Object;
        }

        private static ILogger<T> GetLogger()
        {
            var loggerMock = new Mock<ILogger<T>>();

            return loggerMock.Object;
        }

        private static IConfiguration GetConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"AppSettings:Token", UsersMediatorRequestsMock.APP_TOKEN},
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }

        #endregion
    }
}
