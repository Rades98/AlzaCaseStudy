﻿namespace ApplicationLayer.Requests.ProductDetailInfos.Queries
{
	using Exceptions;
	using Interfaces;
	using Interfaces.Cache;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class ProductDetailInfoGetRequest : IRequest<ProductDetailInfoGetResponse>, ICacheableWithIdQuery
	{
		public int Id { get; set; }
		public string CacheKey => Cache.CacheKeys.ProductDetailInfos;

		public class Handler : IRequestHandler<ProductDetailInfoGetRequest, ProductDetailInfoGetResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<ProductDetailInfoGetResponse> Handle(ProductDetailInfoGetRequest request, CancellationToken cancellationToken)
			{
				var productDetail = await _dbContext.ProductDetailInfos
					.AsNoTracking()
					.Include(i => i.ProductDetail)
					.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

				if (productDetail is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Product detail info not found");
				}

				int productCount = await _dbContext.Products.CountAsync(p => p.Id == request.Id, cancellationToken);
				int reservedProductsCount = await _dbContext.OrderItems.CountAsync(p => p.ProductId == request.Id, cancellationToken);

				var result = (ProductDetailInfoGetResponse)productDetail;
				result.Count = productCount - reservedProductsCount;

				return result;
			}
		}
	}
}
