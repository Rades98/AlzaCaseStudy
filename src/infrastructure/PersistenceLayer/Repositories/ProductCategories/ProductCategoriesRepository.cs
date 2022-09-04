using CodeLists.Exceptions;
using DomainLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Repositories;
using PersistenceLayer.Exceptions;

namespace PersistenceLayer.Repositories.ProductCategories
{
	public class ProductCategoriesRepository : IProductCategoriesRepository
	{
		private readonly IDbContext _dbContext;

		public ProductCategoriesRepository(IDbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		/// <inheritdoc/>
		public async Task<List<ProductCategoryEntity>> GetProductCategoriesAsync(CancellationToken ct)
		{
			var productCategories = await _dbContext.ProductCategories
					.AsNoTracking()
					.ToListAsync(ct);

			if (!productCategories.Any())
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product categories not found");
			}

			return productCategories;
		}

		/// <inheritdoc/>
		public async Task<List<ProductCategoryEntity>> GetProductCategoriesByIdAsync(int id, CancellationToken ct)
		{

			var productCategories = await _dbContext.ProductCategories
					.AsNoTracking()
					.ToListAsync(ct);

			if (productCategories is null || !productCategories.Any() || productCategories.FirstOrDefault(x => x.Id == id) is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product category not found");
			}

			return productCategories;
		}
	}
}
