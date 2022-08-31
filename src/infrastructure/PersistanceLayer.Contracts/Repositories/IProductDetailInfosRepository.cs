namespace PersistanceLayer.Contracts.Repositories
{
	using DomainLayer.Entities.Product;

	public interface IProductDetailInfosRepository
	{
		/// <summary>
		/// Get product detail info
		/// </summary>
		/// <param name="productCode">product code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>product detail info</returns>
		Task<ProductDetailInfoEntity> GetProductDetailInofAsync(string productCode, CancellationToken ct);
	}
}
