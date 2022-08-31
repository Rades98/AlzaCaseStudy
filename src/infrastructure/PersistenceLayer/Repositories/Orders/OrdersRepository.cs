namespace PersistenceLayer.Repositories.OrdersRepository
{
	using System.Linq.Expressions;
	using CodeLists.Exceptions;
	using CodeLists.OrderStatuses;
	using DomainLayer.Entities.Orders;
	using Exceptions;
	using Microsoft.EntityFrameworkCore;
	using PersistanceLayer.Contracts;
	using PersistanceLayer.Contracts.Repositories;
	using AppUtils.Orders;

	public class OrdersRepository : IOrdersRepository
	{
		private readonly IDbContext _dbContext;

		public OrdersRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task OrderChangeStatusAsync(string orderCode, int statusId, int userId, CancellationToken ct)
		{
			var actual = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderCode == orderCode, ct);

			if (actual is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Order not found");
			}

			if (actual.UserId != userId)
			{
				throw new PersistanceLayerException(ExceptionType.Unauthorized, "Wrong user");
			}

			var status = await _dbContext.OrderStatuses.FirstOrDefaultAsync(x => x.Id == statusId, ct);

			if (status is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Status not found");
			}

			if (status.Id - 1 != actual.OrderStatusId)
			{
				throw new PersistanceLayerException(ExceptionType.NotModified, "Status cant be replaced by provided value");
			}

			actual.Status = status;

			try
			{
				_dbContext.Orders.Update(actual);
				await _dbContext.SaveChangesAsync(ct);
			}
			catch (Exception ex)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "Error while changing status", ex);
			}
		}

		/// <inheritdoc/>
		public async Task<string> CreateOrderAsync(int userId, CancellationToken ct)
		{
			var actual = await _dbContext.Orders.Where(x => x.UserId == userId &&
					(x.OrderStatusId == OrderStatuses.New ||
					x.OrderStatusId == OrderStatuses.Created))
					.ToListAsync(ct);

			if (actual is not null && actual.Count > 0)
			{
				throw new PersistanceLayerException(ExceptionType.Error, $"There aleready is unfinished order: {actual.First().OrderCode}");
			}

			string lastOrderCode = (await _dbContext.Orders.OrderBy(x => x.OrderCode).LastOrDefaultAsync(ct))?.OrderCode ?? string.Empty;

			string code = "AAAAA00000";

			if (!string.IsNullOrEmpty(lastOrderCode))
			{
				code = OrderUtils.GetOrderCode(lastOrderCode);
			}

			try
			{
				var status = await _dbContext.OrderStatuses.FirstAsync(x => x.Id == OrderStatuses.New, ct);
				var user = await _dbContext.Users.FirstAsync(x => x.Id == userId, ct);

				_dbContext.Orders.Add(new OrderEntity()
				{
					OrderCode = code,
					UserId = user.Id,
					Total = 0,
					OrderStatusId = status.Id
				});

				await _dbContext.SaveChangesAsync(ct);

				int id = await _dbContext.Orders.Where(x => x.UserId == userId &&
				(x.OrderStatusId == OrderStatuses.New ||
				x.OrderStatusId == OrderStatuses.Created))
				.Select(x => x.Id)
				.FirstOrDefaultAsync(ct);

				return code;
			}
			catch (Exception e)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "Error while creating order", e);
			}
		}

		/// <inheritdoc/>
		public async Task StornoOrderAsync(int userId, string orderCode, CancellationToken ct)
		{
			var order = await _dbContext.Orders
					.Include(i => i.Status!)
					.Include(i => i.Items!)
						.ThenInclude(i => i.Product)
							.ThenInclude(i => i!.ProductDetail)
					.AsNoTracking()
					.FirstOrDefaultAsync(x =>
					x.OrderCode == orderCode
				, ct);

			if (order is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Order not found");
			}

			if (order.UserId != userId)
			{
				throw new PersistanceLayerException(ExceptionType.Unauthorized, "This user can not change this order");
			}

			if (order.OrderStatusId == OrderStatuses.Canceled ||
				order.OrderStatusId == OrderStatuses.Delivered ||
				order.OrderStatusId == OrderStatuses.InExpedition)
			{
				throw new PersistanceLayerException(ExceptionType.Error, "Order cannot be cancelled");
			}

			using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

			try
			{
				order.Status = await _dbContext.OrderStatuses
					.AsNoTracking()
					.FirstAsync(x => x.Id == OrderStatuses.Canceled, ct);

				if (order.Items is not null)
				{
					_dbContext.OrderItems.RemoveRange(order.Items);
					order.Items.Clear();
				}

				_dbContext.Orders.Update(order);

				await _dbContext.SaveChangesAsync(ct);

				await transaction.CommitAsync(ct);

			}
			catch (Exception e)
			{
				transaction.Rollback();

				throw new PersistanceLayerException(ExceptionType.Error, "Error while canceling order", e);
			}
		}

		/// <inheritdoc/>
		public async Task<List<OrderEntity>> GetOrdersByUserId(int userId, Expression<Func<OrderEntity, bool>> whereFilter, CancellationToken ct)
		{
			Expression<Func<OrderEntity, bool>> exp = x => x.UserId == userId;

			return await _dbContext.Orders
				.Include(i => i.Status!)
				.Include(i => i.Items!)
					.ThenInclude(i => i.Product!)
						.ThenInclude(i => i.ProductDetail)
				.AsNoTracking()
				.Where(exp)
				.Where(whereFilter)
				.ToListAsync(ct);
		}
	}
}
