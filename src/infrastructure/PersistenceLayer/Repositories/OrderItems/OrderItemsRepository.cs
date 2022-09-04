using CodeLists.Exceptions;
using CodeLists.OrderStatuses;
using DomainLayer.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Contracts;
using PersistanceLayer.Contracts.Repositories;
using PersistenceLayer.Exceptions;

namespace PersistenceLayer.Repositories.OrderItems
{
	public class OrderItemsRepository : IOrderItemsRepository
	{
		private readonly IDbContext _dbContext;

		public OrderItemsRepository(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task PutOrderItemAsync(string orderCode, string productCode, int userId, CancellationToken ct)
		{
			var order = await _dbContext.Orders
					.Include(i => i.Status)
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.OrderCode == orderCode, ct);

			if (order is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Order not found");
			}

			if (order.UserId != userId)
			{
				throw new PersistanceLayerException(ExceptionType.Unauthorized, "Wrong user");
			}

			if (
				order.OrderStatusId != OrderStatuses.New &&
				order.OrderStatusId != OrderStatuses.Created)
			{
				throw new PersistanceLayerException(ExceptionType.NotModified, "Order is not editable");
			}

			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var usedProductsIds = await _dbContext
					.OrderItems
					.Include(x => x.Product)
						.ThenInclude(x => x!.ProductDetail)
					.Where(w => w.Product != null && w.Product.ProductDetail != null && w.Product.ProductDetail.ProductCode == productCode)
					.Select(x => x.ProductId)
					.ToListAsync(ct);

				var unusedProduct = await _dbContext.Products
					.Include(i => i.ProductDetail)
						.ThenInclude(i => i!.ProductCategory)
					.AsNoTracking()
					.FirstOrDefaultAsync(x => !usedProductsIds.Contains(x.Id) && x.ProductDetail!.ProductCode == productCode, ct);

				if (unusedProduct is null)
				{
					throw new PersistanceLayerException(ExceptionType.NotFound, "ProductNotFound");
				}

				_dbContext.OrderItems.Update(new OrderItemEntity
				{
					Order = order,
					Product = unusedProduct
				});

				if (unusedProduct.ProductDetail is not null)
				{
					order.Total += unusedProduct.ProductDetail.Price;
				}

				_dbContext.Orders.Update(order);

				await _dbContext.SaveChangesAsync(ct);

				transaction.Commit();
			}
			catch (Exception e)
			{
				if (e is PersistanceLayerException)
				{
					throw;
				}

				transaction.Rollback();
				throw new PersistanceLayerException(ExceptionType.Error, "Product addition to order failed", e);
			}
		}

		/// <inheritdoc/>
		public async Task DeleteOrderItemAsync(string orderCode, string productCode, int userId, CancellationToken ct)
		{
			var orderItem = await _dbContext.OrderItems
					.Include(i => i.Order)
						.ThenInclude(i => i!.Status)
					.Include(i => i.Product)
						.ThenInclude(i => i!.ProductDetail)
					.AsNoTracking()
					.FirstOrDefaultAsync(x =>
					x.Product != null && x.Product.ProductDetail != null && x.Order != null &&
					x.Product.ProductDetail.ProductCode == productCode &&
					x.Order.OrderCode == orderCode
					, ct);

			if (orderItem is null)
			{
				throw new PersistanceLayerException(ExceptionType.NotFound, "Order item not found");
			}

			if (orderItem.Order is not null && orderItem.Order.UserId != userId)
			{
				throw new PersistanceLayerException(ExceptionType.Unauthorized, "Order item cannot be deleted by this user");
			}

			using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

			try
			{
				_dbContext.OrderItems.Remove(orderItem);

				var order = orderItem.Order;

				if (order is not null)
				{
					if (orderItem.Product is not null && orderItem.Product.ProductDetail is not null)
					{
						order.Total -= orderItem.Product.ProductDetail.Price;
					}

					_dbContext.Orders.Update(order);

					await _dbContext.SaveChangesAsync(ct);

					await transaction.CommitAsync(ct);
				}
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync(ct);
				throw new PersistanceLayerException(ExceptionType.Error, "Error while deleting", e);
			}
		}

		public async Task<int> GetCountOfItemsByIdAsync(string productCode, CancellationToken ct)
		{
			return await _dbContext.OrderItems
				.AsNoTracking()
				.Include(i => i.Product!)
					.ThenInclude(p => p.ProductDetail!)
				.CountAsync(p => p.Product!.ProductDetail!.ProductCode == productCode, ct);
		}
	}
}
