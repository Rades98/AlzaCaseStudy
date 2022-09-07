using CodeLists.Exceptions;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Models.ProductDetailInfos;
using PersistanceLayer.Contracts.Repositories;
using PersistenceLayer.Exceptions;
using PersistenceLayer.Extensions;

namespace PersistenceLayer.Repositories.ProductDetailInfos
{
	public class ProductDetailInfosRepository : IProductDetailInfosRepository
	{
		private readonly IDbContext _dbContext;

		public ProductDetailInfosRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<ProductDetailInfoModel> GetProductDetailInofAsync(string productCode, CancellationToken ct)
		{
			var productDetailInfo = await _dbContext.ProductDetailInfos
					.AsNoTracking()
					.Include(i => i.ProductDetail)
						.ThenInclude(i => i!.Products)
					.FirstOrDefaultAsync(x => x.ProductDetail!.ProductCode == productCode, ct);

			if (productDetailInfo is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Product detail info not found");
			}

			return productDetailInfo.MapToModel();
		}
	}
}
