using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.ProductDetails.Queries.Requests
{
	public class ProductDetailsGetByCategory : IRequest<IList<ProductDetailGetResponse>>
	{
		public int CategoryId { get; set; }
		public int PageSize { get; set; }
		public int PageNum { get; set; }

		public class Handler : IRequestHandler<ProductDetailsGetByCategory, IList<ProductDetailGetResponse>>
		{
			private readonly IProductDetailsRepository _repo;

			public Handler(IProductDetailsRepository repo, IProductCategoriesRepository catRepo)
			{
				_repo = repo ?? throw new ArgumentNullException(nameof(repo));
			}

			public async Task<IList<ProductDetailGetResponse>> Handle(ProductDetailsGetByCategory request, CancellationToken cancellationToken)
			{
				var products = await _repo.GetProductDetailByCategoryAsync(request.CategoryId, request.PageNum, request.PageSize, cancellationToken);

				return products.Select(x => (ProductDetailGetResponse)x).ToList();
			}
		}
	}
}
