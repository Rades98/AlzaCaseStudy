namespace ApplicationLayer.Services.ProductDetails.Queries.Requests
{
    using ApplicationLayer.Services.ProductDetails.Queries;
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
    public class ProductDetailGetRequest : IRequest<ProductDetailGetResponse?>, ICacheableWithIdQuery
    {
        public Guid Id { get; set; }
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductDetailGetRequest, ProductDetailGetResponse?>
        {
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<ProductDetailGetResponse?> Handle(ProductDetailGetRequest request, CancellationToken cancellationToken)
            {
                var product = await _repo.GetAsync(request.Id, cancellationToken);

                if (product is null)
                {
                    return null;
                }

                return (ProductDetailGetResponse)product;
            }
        }
    }
}
