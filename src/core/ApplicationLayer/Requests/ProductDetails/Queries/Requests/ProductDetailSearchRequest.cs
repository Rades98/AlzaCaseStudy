using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	public class ProductDetailSearchRequest : IRequest<IList<ProductDetailGetResponse>>
	{
		public string Phrase { get; set; } = string.Empty;
		public int PageSize { get; set; }
		public int PageNum { get; set; }

		public class Handler : IRequestHandler<ProductDetailSearchRequest, IList<ProductDetailGetResponse>>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<IList<ProductDetailGetResponse>> Handle(ProductDetailSearchRequest request, CancellationToken cancellationToken)
			{
				var products = await _repo.SearchProductDetailAsync(request.Phrase, request.PageNum, request.PageSize, cancellationToken);

				return products.Select(x => (ProductDetailGetResponse)x).ToList();
			}
		}
	}
}
