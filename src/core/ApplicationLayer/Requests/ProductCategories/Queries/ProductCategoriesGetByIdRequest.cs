using ApplicationLayer.Dtos;
using ApplicationLayer.Interfaces.Cache;
using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	public class ProductCategoriesGetByIdRequest : IRequest<ProductCategoriesGetResponse>, ICacheableQuery
	{
		public int Id { get; set; }
		public string CacheKey => Cache.CacheKeys.ProductCetegories;

		public class Handler : IRequestHandler<ProductCategoriesGetByIdRequest, ProductCategoriesGetResponse>
		{
			private readonly IProductCategoriesRepository _repo;

			public Handler(IProductCategoriesRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<ProductCategoriesGetResponse> Handle(ProductCategoriesGetByIdRequest request, CancellationToken cancellationToken)
			{
				var productCategories = await _repo.GetProductCategoriesByIdAsync(request.Id, cancellationToken);

				productCategories.ForEach(cat =>
				{
					cat.ChildrenCategories = productCategories.Where(x => x.ParentProductCategoryId == cat.Id).ToList();
				});

				return new ProductCategoriesGetResponse { CategoryTree = (ProductCategoryDto)productCategories.First(x => x.Id == request.Id) };
			}
		}
	}
}
