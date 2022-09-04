namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	using ApplicationLayer.Requests.ProductDetails.Queries;
	using DomainLayer.Entities.Product;
	using Interfaces.Cache;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	/// <summary>
	/// Query to obtain all products
	/// </summary>
	/// <returns>
	///  List of products or null, if there are none
	/// </returns>
	public class ProductDetailsGetRequest : IRequest<IEnumerable<ProductDetailGetResponse>>, ICacheableQuery
	{
		public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
		public bool OrderByDesc { get; set; } = false;
		public string CacheKey => Cache.CacheKeys.ProductDetails;

		public class Handler : IRequestHandler<ProductDetailsGetRequest, IEnumerable<ProductDetailGetResponse>>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<IEnumerable<ProductDetailGetResponse>> Handle(ProductDetailsGetRequest request, CancellationToken cancellationToken)
			{
				var products = await _repo.GetProductDetailsAsync(request.OrderBy, request.OrderByDesc, cancellationToken);

				return products.Select(x => (ProductDetailGetResponse)x);
			}
		}
	}
}
