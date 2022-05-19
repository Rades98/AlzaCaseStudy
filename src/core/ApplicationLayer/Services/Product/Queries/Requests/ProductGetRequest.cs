namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using DomainLayer.Entities.Product;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Query to obtain product by id
    /// </summary>
    /// <returns>
    /// product with specified id if there is none returns null
    /// </returns>
    public class ProductGetRequest : IRequest<ProductGetResponse?>, ICacheableWithIdQuery
    {
        public Guid Id { get; set; }
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductGetRequest, ProductGetResponse?>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<ProductGetResponse?> Handle(ProductGetRequest request, CancellationToken cancellationToken)
            {
                var product = await _repo.GetAsync(request.Id, cancellationToken);

                if (product is null)
                {
                    return null;
                }

                return (ProductGetResponse)product;
            }
        }
    }
}
