namespace ApplicationLayer.Requests.OrderItems.Commands.Put
{
	using CodeLists.OrderStatuses;
	using DomainLayer.Entities.Orders;
	using Exceptions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using System.Threading;
	using System.Threading.Tasks;

	public class OrderItemPutRequest : IRequest<OrderItemPutResponse>
	{
		public string ProductCode { get; set; } = string.Empty;
		public string OrderCode { get; set; } = string.Empty;
		public Guid UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemPutRequest, OrderItemPutResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<OrderItemPutResponse> Handle(OrderItemPutRequest request, CancellationToken cancellationToken)
			{
				var order = await _dbContext.Orders
					.Include(i => i.Status)
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.OrderCode == request.OrderCode, cancellationToken);

				if (order is null)
				{
					throw new CRUDException(ExceptionTypeEnum.NotFound, "Order not found");
				}

				if (order.UserId != request.UserId)
				{
					throw new CRUDException(ExceptionTypeEnum.Unauthorized, "Wrong user");
				}

				if (
					order.OrderStatusId != OrderStatuses.New &&
					order.OrderStatusId != OrderStatuses.Created)
				{
					throw new CRUDException(ExceptionTypeEnum.Error, "Order is not editable");
				}


				using var transaction = _dbContext.Database.BeginTransaction();
				try
				{
					var usedProductsIds = await _dbContext
						.OrderItems
						.Include(x => x.Product)
							.ThenInclude(x => x.ProductDetail)
						.Where(w => w.Product.ProductDetail.ProductCode == request.ProductCode)
						.Select(x => x.ProductId)
						.ToListAsync(cancellationToken);

					var unusedProduct = await _dbContext.Products
						.Include(i => i.ProductDetail)
							.ThenInclude(i => i.ProductCategory)
						.AsNoTracking()
						.FirstOrDefaultAsync(x => !usedProductsIds.Contains(x.Id) && x.ProductDetail.ProductCode == request.ProductCode, cancellationToken);

					if (unusedProduct is null)
					{
						throw new CRUDException(ExceptionTypeEnum.NotFound, "ProductNotFound");
					}

					_dbContext.OrderItems.Update(new OrderItemEntity
					{
						Order = order,
						Product = unusedProduct
					});

					order.Total += unusedProduct.ProductDetail.Price;

					_dbContext.Orders.Update(order);

					await _dbContext.SaveChangesAsync(cancellationToken);

					transaction.Commit();

					return new OrderItemPutResponse() { Message = "OK" };
				}
				catch (Exception e)
				{
					transaction.Rollback();
					throw new CRUDException(ExceptionTypeEnum.Error, "Product addition to order failed", e);
				}

			}
		}
	}
}
