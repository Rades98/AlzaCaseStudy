namespace ApplicationLayer.Services.ProductDetails.Queries.Requests
{
    using ApplicationLayer.Services.ProductDetails.Queries;
    using DomainLayer.Entities.Product;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Query to obtain product by id
    /// </summary>
    /// <returns>
    /// product with specified id if there is none returns null
    /// </returns>
    public class ProductDetailGetRequest : IRequest<ProductDetailGetResponse?>, ICacheableWithIdQuery
    {
        public Guid Id { get; set; }
        public string CacheKey => Cache.CacheKeys.ProductDetails;

        public class Handler : IRequestHandler<ProductDetailGetRequest, ProductDetailGetResponse?>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductDetailGetResponse?> Handle(ProductDetailGetRequest request, CancellationToken cancellationToken)
            {
                var product = await _dbContext.ProductDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);

                if (product is null)
                {
                    return null;
                }

                return (ProductDetailGetResponse)product;
            }
        }
    }
}
