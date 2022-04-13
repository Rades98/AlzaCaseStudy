namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Extensions.LINQ;
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using MediatR;
    using X.PagedList;

    public class ProductsGetPaginatedRequest : IRequest<IEnumerable<ProductGetResponse>>
    {
        public Func<ProductEntity, object> OrderBy { internal get; set; } = product => product.Id;
        public bool OrderByDesc { internal get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public class Handler : IRequestHandler<ProductsGetPaginatedRequest, IEnumerable<ProductGetResponse>>
        {
            private IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<IEnumerable<ProductGetResponse>> Handle(ProductsGetPaginatedRequest request, CancellationToken cancellationToken)
            {
                var products = await _dbContext.Products
                    .IfThenElse(
                        () => request.OrderByDesc,
                        e => e.OrderByDescending(request.OrderBy),
                        e => e.OrderBy(request.OrderBy))
                    .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);

                return products.Select(x => (ProductGetResponse)x);
            }
        }
    }
}
