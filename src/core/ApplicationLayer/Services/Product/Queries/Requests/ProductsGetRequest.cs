namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Interfaces.Cache;
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
        public Func<ProductEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductsGetRequest, IEnumerable<ProductGetResponse>?>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductGetResponse>?> Handle(ProductsGetRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllAsync(request.OrderByDesc, request.OrderBy, cancellationToken);

                if(products.Count > 0)
                {
                    return products.Select(x => (ProductGetResponse)x);
                }

                return null;           
            }
        }
    }
}
