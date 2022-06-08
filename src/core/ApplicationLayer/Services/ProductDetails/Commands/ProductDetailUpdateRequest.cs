namespace ApplicationLayer.Services.ProductDetails.Commands
{
    using DomainLayer.Entities.Product;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Request handling request for updating description of product choosen by Id
    /// </summary>
    /// <returns>
    /// Update state optionaly updated message
    /// </returns>
    public class ProductDetailUpdateRequest : IRequest<ProductDetailUpdateResponse>, IInvalidableCommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";
        public string CacheKey => Cache.CacheKeys.ProductDetails;

        public class Handler : IRequestHandler<ProductDetailUpdateRequest, ProductDetailUpdateResponse>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductDetailUpdateResponse> Handle(ProductDetailUpdateRequest request, CancellationToken cancellationToken)
            {
                var response = new ProductDetailUpdateResponse();
                var entity = await _dbContext.ProductDetails
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity is null)
                {
                    return response;
                }

                if (entity.Description == request.Description)
                {
                    response.UpdateMessage = ProductDetailCommandMessages.UpToDate;
                    response.UpToDate = true;
                    return response;
                }

                try
                {
                    entity.Description = request.Description;
                    response.UpdateMessage = $"Product ({entity.Id} : {entity.Name}) has been updated with description \"{entity.Description}\"";
                    response.Updated = response.UpToDate = true;

                    _dbContext.ProductDetails.Update(entity);
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
