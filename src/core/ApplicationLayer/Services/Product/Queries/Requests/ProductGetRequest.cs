namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductGetRequest : IRequest<ProductGetResponse>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<ProductGetRequest, ProductGetResponse>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<ProductGetResponse> Handle(ProductGetRequest request, CancellationToken cancellationToken)
            {
                var product = await _repo.Get(request.Id);

                if (product is null)
                {
                    return new ProductGetResponse();
                }

                return (ProductGetResponse)product;
            }
        }
    }
}
