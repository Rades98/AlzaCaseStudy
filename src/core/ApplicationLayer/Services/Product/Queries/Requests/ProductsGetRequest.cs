namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using MediatR;

    public class ProductsGetRequest : IRequest<IEnumerable<ProductGetResponse>>
    {
        public Func<ProductEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;

        public class Handler : IRequestHandler<ProductsGetRequest, IEnumerable<ProductGetResponse>>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductGetResponse>> Handle(ProductsGetRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAll(request.OrderByDesc, request.OrderBy);

                return products.Select(x => (ProductGetResponse)x);
            }
        }
    }
}
