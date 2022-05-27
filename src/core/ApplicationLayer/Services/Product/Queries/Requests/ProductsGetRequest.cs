namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using Interfaces.Cache;
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;

    /// <summary>
    /// Query to obtain all products
    /// </summary>
    /// <returns>
    ///  List of products or null, if there are none
    /// </returns>
    public class ProductsGetRequest : IRequest<IEnumerable<ProductGetResponse>>, ICacheableQuery
    {
        public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductsGetRequest, IEnumerable<ProductGetResponse>?>
        {
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductGetResponse>?> Handle(ProductsGetRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllAsync(request.OrderByDesc, request.OrderBy, cancellationToken);

                if (products.Count > 0)
                {
                    return products.Select(x => (ProductGetResponse)x);
                }

                return null;
            }
        }
    }
}
