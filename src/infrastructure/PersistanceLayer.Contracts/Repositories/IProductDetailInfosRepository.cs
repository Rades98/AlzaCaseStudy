using PersistanceLayer.Contracts.Models.ProductDetailInfos;

namespace PersistanceLayer.Contracts.Repositories
{
	public interface IProductDetailInfosRepository
	{
		/// <summary>
		/// Get product detail info
		/// </summary>
		/// <param name="productCode">product code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>product detail info</returns>
		Task<ProductDetailInfoModel> GetProductDetailInofAsync(string productCode, CancellationToken ct);
	}
}
