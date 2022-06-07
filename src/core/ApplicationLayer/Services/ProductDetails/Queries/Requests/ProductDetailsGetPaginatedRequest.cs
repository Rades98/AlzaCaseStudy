namespace ApplicationLayer.Services.ProductDetails.Queries.Requests
{
    using ApplicationLayer.Services.ProductDetails.Queries;
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;

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
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductDetailGetResponse>?> Handle(ProductDetailsGetPaginatedRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllPaginatedAsync(request.PageNumber, request.PageSize, request.OrderByDesc, request.OrderBy, cancellationToken);

                if (products.Count > 0)
                {
                    return products.Select(x => (ProductDetailGetResponse)x);
                }

                return null;
            }
        }
    }
}
