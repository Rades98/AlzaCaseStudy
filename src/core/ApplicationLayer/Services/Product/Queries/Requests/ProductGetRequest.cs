namespace ApplicationLayer.Services.Product.Queries.Requests
{
    using ApplicationLayer.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductGetRequest : IRequest<ProductGetResponse>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<ProductGetRequest, ProductGetResponse>
        {
            private IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductGetResponse> Handle(ProductGetRequest request, CancellationToken cancellationToken)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if(product is null)
                {
                    return new ProductGetResponse();
                }

                return (ProductGetResponse)product;
            }
        }
    }
}
