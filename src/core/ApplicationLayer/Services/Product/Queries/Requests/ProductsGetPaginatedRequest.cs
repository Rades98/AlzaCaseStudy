namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;

    /// <summary>
    /// Query to obtain all products wit pagination settings
    /// </summary>
    /// <returns>
    /// Paged list of products, if not found then null
    /// </returns>
    public class ProductsGetPaginatedRequest : IRequest<IEnumerable<ProductGetResponse>>
    {
        public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public class Handler : IRequestHandler<ProductsGetPaginatedRequest, IEnumerable<ProductGetResponse>?>
        {
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductGetResponse>?> Handle(ProductsGetPaginatedRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllPaginatedAsync(request.PageNumber, request.PageSize, request.OrderByDesc, request.OrderBy, cancellationToken);

                if (products.Count > 0)
                {
                    return products.Select(x => (ProductGetResponse)x);
                }

                return null;
            }
        }
    }
}
