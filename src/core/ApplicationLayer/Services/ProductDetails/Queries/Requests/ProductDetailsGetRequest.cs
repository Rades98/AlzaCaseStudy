namespace ApplicationLayer.Services.ProductDetails.Queries.Requests
{
    using Interfaces.Cache;
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;
    using ApplicationLayer.Services.ProductDetails.Queries;

    /// <summary>
    /// Query to obtain all products
    /// </summary>
    /// <returns>
    ///  List of products or null, if there are none
    /// </returns>
    public class ProductDetailsGetRequest : IRequest<IEnumerable<ProductDetailGetResponse>>, ICacheableQuery
    {
        public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductDetailsGetRequest, IEnumerable<ProductDetailGetResponse>?>
        {
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductDetailGetResponse>?> Handle(ProductDetailsGetRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllAsync(request.OrderByDesc, request.OrderBy, cancellationToken);

                if (products.Count > 0)
                {
                    return products.Select(x => (ProductDetailGetResponse)x);
                }

                return null;
            }
        }
    }
}
