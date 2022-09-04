namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	using Dtos;
	using Interfaces.Cache;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class ProductCategoriesGetRequest : IRequest<ProductCategoriesGetResponse>, ICacheableQuery
	{
		public string CacheKey => Cache.CacheKeys.ProductCetegories;

		public class Handler : IRequestHandler<ProductCategoriesGetRequest, ProductCategoriesGetResponse?>
		{
			private readonly IProductCategoriesRepository _repo;

			public Handler(IProductCategoriesRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<ProductCategoriesGetResponse?> Handle(ProductCategoriesGetRequest request, CancellationToken cancellationToken)
			{
				var productCategories = await _repo.GetProductCategoriesAsync(cancellationToken);

				productCategories.ToList().ForEach(cat =>
				{
					cat.ChildrenCategories = productCategories.Where(x => x.ParentProductCategoryId == cat.Id).ToList();
				});

				return new ProductCategoriesGetResponse { CategoryTree = (ProductCategoryDto)productCategories.First() };
			}
		}
	}
}
