namespace ApplicationLayer.Services.ProductCategories.Queries
{
    using DomainLayer.Entities.Product;
    using Dtos;
    using Interfaces;
    using Interfaces.Cache;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class ProductCategoriesGetRequest : IRequest<ProductCategoriesGetResponse?>, ICacheableQuery
    {
        public string CacheKey => Cache.CacheKeys.ProductCetegories;

        public class Handler : IRequestHandler<ProductCategoriesGetRequest, ProductCategoriesGetResponse?>
        {
            private readonly IDbContext _dbContext;

            public Handler(IDbContext dbContext) => _dbContext = dbContext;

            public async Task<ProductCategoriesGetResponse?> Handle(ProductCategoriesGetRequest request, CancellationToken cancellationToken)
            {
                var productCategories = await _dbContext.ProductCategories
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                productCategories.ToList().ForEach(cat =>
                {
                    cat.ChildrenCategories = productCategories.Where(x => x.ParentProductCategoryId == cat.Id).ToList();
                });

                return new ProductCategoriesGetResponse { CategoryTree = (ProductCategoryDto)productCategories.First() };
            }
        }
    }
}
