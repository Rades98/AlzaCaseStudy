namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Extensions.LINQ;
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    internal class ProductsGetRequest : IRequest<IEnumerable<ProductGetResponse>>
    {
        public Func<ProductEntity, object> OrderBy { internal get; set; } = product => product.Id;
        public bool OrderByDesc { internal get; set; } = false;

        public class Handler : IRequestHandler<ProductsGetRequest, IEnumerable<ProductGetResponse>>
        {
            private IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<IEnumerable<ProductGetResponse>> Handle(ProductsGetRequest request, CancellationToken cancellationToken)
            {
                var products = await _dbContext.Products
                    .ToListAsync(cancellationToken);

                return products
                    .IfThenElse(
                        () => request.OrderByDesc,
                        e => e.OrderByDescending(request.OrderBy),
                        e => e.OrderBy(request.OrderBy))
                    .Select(x => (ProductGetResponse)x);
            }
        }
    }
}
