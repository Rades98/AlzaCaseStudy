namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	using ApplicationLayer.Requests.ProductDetails.Queries;
	using DomainLayer.Entities.Product;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	/// <summary>
	/// Query to obtain all products wit pagination settings
	/// </summary>
	/// <returns>
	/// Paged list of products, if not found then null
	/// </returns>
	public class ProductDetailsGetPaginatedRequest : IRequest<IEnumerable<ProductDetailGetResponse>>
	{
		public Func<ProductDetailEntity, object> OrderBy { get; set; } = product => product.Id;
		public bool OrderByDesc { get; set; } = false;

		public int PageNumber { get; set; } = 1;

		public int PageSize { get; set; } = 10;

		public class Handler : IRequestHandler<ProductDetailsGetPaginatedRequest, IEnumerable<ProductDetailGetResponse>>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<IEnumerable<ProductDetailGetResponse>> Handle(ProductDetailsGetPaginatedRequest request, CancellationToken cancellationToken)
			{
				var products = await _repo.GetProductDetailsPaginatedAsync(request.PageNumber, request.PageSize, request.OrderBy, request.OrderByDesc, cancellationToken);

				return products.Select(x => (ProductDetailGetResponse)x);
			}
		}
	}
}
