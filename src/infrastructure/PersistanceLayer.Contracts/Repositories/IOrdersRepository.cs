using System.Linq.Expressions;
using DomainLayer.Entities.Orders;
using PersistanceLayer.Contracts.Models.Orders;

namespace PersistanceLayer.Contracts.Repositories
{
	public interface IOrdersRepository
	{
		/// <summary>
		/// Order change status
		/// </summary>
		/// <param name="orderCode">order code</param>
		/// <param name="statusId">status id</param>
		/// <param name="userId">user id</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task OrderChangeStatusAsync(string orderCode, int statusId, int userId, CancellationToken ct);

		/// <summary>
		/// Create order
		/// </summary>
		/// <param name="userId">user id</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task<string> CreateOrderAsync(int userId, CancellationToken ct);

		/// <summary>
		/// Storno order
		/// </summary>
		/// <param name="userId">user id</param>
		/// <param name="orderCode">order code</param>
		/// <param name="ct">cancellation token</param>
		/// <returns></returns>
		Task StornoOrderAsync(int userId, string orderCode, CancellationToken ct);

		/// <summary>
		/// Get orders for specific user
		/// </summary>
		/// <param name="userId">user id</param>
		/// <param name="whereFilter">filter</param>
		/// <param name="ct">cancellation token</param>
		/// <returns>List of orders acceptiong filter criteria</returns>
		Task<List<OrderModel>> GetOrdersByUserId(int userId, Expression<Func<OrderEntity, bool>> whereFilter, CancellationToken ct);
	}
}
