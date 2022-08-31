namespace PersistenceLayer.Repositories.ProductDetailInfos
{
	using CodeLists.Exceptions;
	using DomainLayer.Entities.Product;
	using Microsoft.EntityFrameworkCore;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;
	using PersistenceLayer.Exceptions;

	public class ProductDetailInfosRepository : IProductDetailInfosRepository
	{
		private readonly IDbContext _dbContext;

		public ProductDetailInfosRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<ProductDetailInfoEntity> GetProductDetailInofAsync(string productCode, CancellationToken ct)
		{
			var productDetailInfo = await _dbContext.ProductDetailInfos
					.AsNoTracking()
					.Include(i => i.ProductDetail)
					.FirstOrDefaultAsync(x => x.ProductDetail!.ProductCode == productCode, ct);

			if (productDetailInfo is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product detail info not found");
			}

			return productDetailInfo;
		}
	}
}
