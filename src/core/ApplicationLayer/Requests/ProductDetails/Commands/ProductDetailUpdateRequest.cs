namespace ApplicationLayer.Requests.ProductDetails.Commands
{
	using System.Threading;
	using System.Threading.Tasks;
	using Interfaces.Cache;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	/// <summary>
	/// Request handling request for updating description of product choosen by Id
	/// </summary>
	/// <returns>
	/// Update state optionaly updated message
	/// </returns>
	public class ProductDetailUpdateRequest : IRequest<ProductDetailUpdateResponse>, IInvalidableCommand
	{
		public int Id { get; set; }
		public string Description { get; set; } = "";
		public string CacheKey => Cache.CacheKeys.ProductDetails;

		public class Handler : IRequestHandler<ProductDetailUpdateRequest, ProductDetailUpdateResponse>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<ProductDetailUpdateResponse> Handle(ProductDetailUpdateRequest request, CancellationToken cancellationToken)
			{
				var response = new ProductDetailUpdateResponse();

				var updatedEntity = await _repo.UpdateProductDetailDescriptionAsync(request.Id, request.Description, cancellationToken);

				response.UpdateMessage = $"Product ({updatedEntity.Id} : {updatedEntity.Name}) has been updated with description \"{updatedEntity.Description}\"";
				response.Updated = response.UpToDate = true;

				return response;
			}
		}
	}
}
