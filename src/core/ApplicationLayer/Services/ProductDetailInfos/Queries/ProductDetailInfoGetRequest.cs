namespace ApplicationLayer.Services.ProductDetailInfos.Queries
{
    using DomainLayer.Entities.Product;
    using DomainLayer.Entities.Orders;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductDetailInfoGetRequest : IRequest<ProductDetailInfoGetResponse?>, ICacheableWithIdQuery
    {
        public Guid Id { get; set; }
        public string CacheKey => Cache.CacheKeys.ProductDetailInfos;

        public class Handler : IRequestHandler<ProductDetailInfoGetRequest, ProductDetailInfoGetResponse?>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductDetailInfoGetResponse?> Handle(ProductDetailInfoGetRequest request, CancellationToken cancellationToken)
            {
                var productDetail = await _dbContext.ProductDetailInfos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (productDetail is null)
                {
                    return null;
                }

                var productCount = await _dbContext.Products.CountAsync(p => p.Id == request.Id, cancellationToken);
                var reservedProductsCount = await _dbContext.OrderItems.CountAsync(p => p.ProductId == request.Id, cancellationToken);

                var result = (ProductDetailInfoGetResponse)productDetail;
                result.Count = productCount - reservedProductsCount;

                return result;
            }
        }
    }
}
