namespace ApplicationLayer.Services.Product.Commands
{
    using ApplicationLayer.Interfaces;
    using DomainLayer.Entities.Product;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductUpdateRequest : IRequest<ProductUpdateResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = "";

        public class Handler : IRequestHandler<ProductUpdateRequest, ProductUpdateResponse>
        {
            private readonly IGenericRepository<ProductEntity> _repo;

            public Handler(IGenericRepository<ProductEntity> repo) => _repo = repo;

            public async Task<ProductUpdateResponse> Handle(ProductUpdateRequest request, CancellationToken cancellationToken)
            {
                var response = new ProductUpdateResponse();
                var entity = await _repo.Get(request.Id);

                if (entity is null)
                {
                    return response;
                }

                if(entity.Description == request.Description)
                {
                    response.UpdateMessage = CommandMessages.UpToDate;
                    response.UpToDate = true;
                    return response;
                }

                try
                {
                    entity.Description = request.Description;
                    response.UpdateMessage = $"Product ({entity.Id} : {entity.Name}) has been updated with description \"{entity.Description}\"";
                    response.Updated = response.UpToDate = true;

                    await _repo.Update(entity);
 
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
