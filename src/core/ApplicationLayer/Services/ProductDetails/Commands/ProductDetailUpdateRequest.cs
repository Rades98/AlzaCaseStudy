namespace ApplicationLayer.Services.ProductDetails.Commands
{
    using DomainLayer.Entities.Product;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
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
        public string CacheKey => Cache.CacheKeys.Products;

        public class Handler : IRequestHandler<ProductDetailUpdateRequest, ProductDetailUpdateResponse>
        {
            private readonly IGenericRepository<ProductDetailEntity> _repo;

            public Handler(IGenericRepository<ProductDetailEntity> repo) => _repo = repo;

            public async Task<ProductDetailUpdateResponse> Handle(ProductDetailUpdateRequest request, CancellationToken cancellationToken)
            {
                var response = new ProductDetailUpdateResponse();
                var entity = await _repo.GetAsync(request.Id, cancellationToken);

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

                    await _repo.UpdateAsync(entity, cancellationToken);

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
