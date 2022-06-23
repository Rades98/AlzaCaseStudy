namespace ApplicationLayer.Requests.ProductCategories.Queries
{
	using Exceptions;
	using Dtos;
	using Interfaces;
	using Interfaces.Cache;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class ProductCategoriesGetByIdRequest : IRequest<ProductCategoriesGetResponse>, ICacheableQuery
	{
		public int Id { get; set; }
		public string CacheKey => Cache.CacheKeys.ProductCetegories;

		public class Handler : IRequestHandler<ProductCategoriesGetByIdRequest, ProductCategoriesGetResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<ProductCategoriesGetResponse> Handle(ProductCategoriesGetByIdRequest request, CancellationToken cancellationToken)
			{
				var productCategories = await _dbContext.ProductCategories
					.AsNoTracking()
					.ToListAsync(cancellationToken);

				if (!productCategories.Any())
				{
					throw new CRUDException(ExceptionTypeEnum.NotFound, "Product category not found");
				}

				productCategories.ForEach(cat =>
				{
					cat.ChildrenCategories = productCategories.Where(x => x.ParentProductCategoryId == cat.Id).ToList();
				});

				return new ProductCategoriesGetResponse { CategoryTree = (ProductCategoryDto)productCategories.First(x => x.Id == request.Id) };
			}
		}
	}
}
