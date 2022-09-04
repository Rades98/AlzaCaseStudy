using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	/// <summary>
	/// Query to obtain product by id
	/// </summary>
	/// <returns>
	/// product with specified id if there is none returns null
	/// </returns>
	public class ProductDetailGetRequest : IRequest<ProductDetailGetResponse>
	{
		public string ProductCode { get; set; } = string.Empty;

		public class Handler : IRequestHandler<ProductDetailGetRequest, ProductDetailGetResponse>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<ProductDetailGetResponse> Handle(ProductDetailGetRequest request, CancellationToken cancellationToken)
			{
				return (ProductDetailGetResponse)await _repo.GetProductDetailByProductCode(request.ProductCode, cancellationToken);
			}
		}
	}
}
