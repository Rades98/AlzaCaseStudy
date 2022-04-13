namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using DomainLayer.Entities.Product;
    using Interfaces;
    using MediatR;

    public class ProductsGetPaginatedRequest : IRequest<IEnumerable<ProductGetResponse>>
    {
        public Func<ProductEntity, object> OrderBy { get; set; } = product => product.Id;
        public bool OrderByDesc { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public class Handler : IRequestHandler<ProductsGetPaginatedRequest, IEnumerable<ProductGetResponse>>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<IEnumerable<ProductGetResponse>> Handle(ProductsGetPaginatedRequest request, CancellationToken cancellationToken)
            {
                var products = await _repo.GetAllPaginated(request.PageNumber, request.PageSize, request.OrderByDesc, request.OrderBy);

                return products.Select(x => (ProductGetResponse)x);
            }
        }
    }
}
