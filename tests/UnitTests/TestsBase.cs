using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Repositories;

namespace UnitTests
{
	public class TestsBase
	{
		private readonly ServiceCollectionProvider _services = new();

		private readonly IDbContext _dbContext;
		private readonly IMediator _mediator;
		private readonly ClaimsPrincipal _claims;

		private readonly IOrderItemsRepository _orderItemsRepo;
		private readonly IOrdersRepository _ordersRepo;
		private readonly IProductCategoriesRepository _productCategoriesRepo;
		private readonly IProductDetailInfosRepository _productDetailInfosRepo;
		private readonly IProductDetailsRepository _productDetailsRepo;
		private readonly IProductsRepository _productsRepo;
		private readonly IUsersRepository _usersRepo;

		public IDbContext DbContext => _dbContext;
		public IMediator Mediator => _mediator;
		public ClaimsPrincipal Claims => _claims;
		public byte[] Token => _services.Token;


		public IOrderItemsRepository OrderItemsRepo => _orderItemsRepo;
		public IOrdersRepository OrdersRepo => _ordersRepo;
		public IProductCategoriesRepository ProductCategoriesRepo => _productCategoriesRepo;
		public IProductDetailInfosRepository ProductDetailInfosRepo => _productDetailInfosRepo;
		public IProductDetailsRepository ProductDetailsRepo => _productDetailsRepo;
		public IProductsRepository ProductsRepo => _productsRepo;
		public IUsersRepository UsersRepo => _usersRepo;

		public TestsBase()
		{
			_dbContext = _services.GetService<IDbContext>();
			_mediator = _services.GetService<IMediator>();
			_claims = new Mock<ClaimsPrincipal>().Object;

			_orderItemsRepo = _services.GetService<IOrderItemsRepository>();
			_ordersRepo = _services.GetService<IOrdersRepository>();
			_productCategoriesRepo = _services.GetService<IProductCategoriesRepository>();
			_productDetailInfosRepo = _services.GetService<IProductDetailInfosRepository>();
			_productDetailsRepo = _services.GetService<IProductDetailsRepository>();
			_productsRepo = _services.GetService<IProductsRepository>();
			_usersRepo = _services.GetService<IUsersRepository>();
		}

		public T GetController<T>() where T : ControllerBase
		{
			return _services.GetService<T>();
		}
	}
}
