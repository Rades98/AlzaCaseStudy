namespace ApplicationLayer.Services.ProductDetails.Queries.Requests
{
    using ApplicationLayer.Services.ProductDetails.Queries;
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;
    using Extensions;
    using X.PagedList;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Query to obtain all products wit pagination settings
    /// </summary>
    /// <returns>
    /// Paged list of products, if not found then null
    /// </returns>
    public class ProductDetailsGetPaginatedRequest : IRequest<IEnumerable<ProductDetailGetResponse>>
    {
        public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public class Handler : IRequestHandler<ProductDetailsGetPaginatedRequest, IEnumerable<ProductDetailGetResponse>?>
        {
            private readonly IDbContext _dbContext;
            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<IEnumerable<ProductDetailGetResponse>?> Handle(ProductDetailsGetPaginatedRequest request, CancellationToken cancellationToken)
            {
                var products = await _dbContext.ProductDetails
                    .AsNoTracking()
                    .IfThenElse(
                        () => request.OrderByDesc,
                        e => e.OrderByDescending(request.OrderBy),
                        e => e.OrderBy(request.OrderBy))
                    .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);

                if (products.Count > 0)
                {
                    return products.Select(x => (ProductDetailGetResponse)x);
                }

                return null;
            }
        }
    }
}
