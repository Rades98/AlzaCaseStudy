namespace PersistanceLayer.Contracts.Repositories
{
	public interface IOrderItemsRepository
	{
		/// <summary>
		/// Put order item to order
		/// </summary>
		/// <param name="orderCode">order code</param>
		/// <param name="productCode">product code</param>
		/// <param name="userId">user id </param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task PutOrderItemAsync(string orderCode, string productCode, int userId, CancellationToken ct);

		/// <summary>
		/// Delete order item
		/// </summary>
		/// <param name="orderCode">order code</param>
		/// <param name="productCode">product code</param>
		/// <param name="userId">user id </param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task DeleteOrderItemAsync(string orderCode, string productCode, int userId, CancellationToken ct);

		/// <summary>
		/// Get count of available items
		/// </summary>
		/// <param name="productCode">product code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task<int> GetCountOfItemsByIdAsync(string productCode, CancellationToken ct);
	}
}
