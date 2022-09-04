namespace PersistanceLayer.Contracts.Repositories
{
	public interface IProductsRepository
	{
		/// <summary>
		/// Get count of product by code
		/// </summary>
		/// <param name="productCode">product code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>count</returns>
		Task<int> GetProductCountByCodeAsync(string productCode, CancellationToken ct);
	}
}
