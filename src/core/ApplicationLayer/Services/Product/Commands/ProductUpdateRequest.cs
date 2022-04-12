namespace ApplicationLayer.Services.Product.Commands
{
    using ApplicationLayer.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductUpdateRequest : IRequest<ProductUpdateResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";

        public class Handler : IRequestHandler<ProductUpdateRequest, ProductUpdateResponse>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductUpdateResponse> Handle(ProductUpdateRequest request, CancellationToken cancellationToken)
            {
                var response = new ProductUpdateResponse();
                var entity = await _dbContext.Products.FindAsync(request.Id);

                if (entity is null)
                {
                    return response;
                }

                if(entity.Description == request.Description)
                {
                    response.UpdateMessage = "Product is already up to date";
                    return response;
                }

                try
                {
                    entity.Description = request.Description;
                    response.UpdateMessage = $"Product ({entity.Id} : {entity.Name}) has been updated with description {entity.Description}";
                    response.Updated = true;

                    _dbContext.Products.Update(entity);
                    await _dbContext.SaveChangesAsync(cancellationToken);
 
                }
                catch (Exception ex)
                {
                    response.Updated = false;
                    response.UpdateMessage = ex.Message;
                }

                return response;

            }
        }
    }
}
