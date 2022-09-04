namespace PersistenceLayer.Repositories.Products
{
	using Microsoft.EntityFrameworkCore;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;

	public class ProductsRepository : IProductsRepository
	{
		private readonly IDbContext _dbContext;

		public ProductsRepository(IDbContext dbContext) => _dbContext = dbContext;

		public async Task<int> GetProductCountByCodeAsync(string productCode, CancellationToken ct)
		{
			return await _dbContext.Products
				.AsNoTracking()
				.Include(i => i.ProductDetail!)
				.CountAsync(p => p.ProductDetail!.ProductCode == productCode, ct);
		}
	}
}
