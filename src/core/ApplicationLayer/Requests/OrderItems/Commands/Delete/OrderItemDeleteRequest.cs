namespace ApplicationLayer.Requests.OrderItems.Commands.Delete
{
	using Exceptions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using System.Threading;
	using System.Threading.Tasks;

	public class OrderItemDeleteRequest : IRequest<OrderItemDeleteResponse>
	{
		public string OrderCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemDeleteRequest, OrderItemDeleteResponse>
		{
			private readonly IDbContext _context;

			public Handler(IDbContext context) => _context = context;

			public async Task<OrderItemDeleteResponse> Handle(OrderItemDeleteRequest request, CancellationToken cancellationToken)
			{
				var orderItem = await _context.OrderItems
					.Include(i => i.Order)
						.ThenInclude(i => i!.Status)
					.Include(i => i.Product)
						.ThenInclude(i => i!.ProductDetail)
					.AsNoTracking()
					.FirstOrDefaultAsync(x =>
					x.Product != null && x.Product.ProductDetail != null && x.Order != null &&
					x.Product.ProductDetail.ProductCode == request.ProductCode &&
					x.Order.OrderCode == request.OrderCode
					, cancellationToken);

				if (orderItem is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Order item not found");
				}

				if (orderItem.Order is not null && orderItem.Order.UserId != request.UserId)
				{
					throw new MediatorException(ExceptionType.Unauthorized, "Order item cannot be deleted by this user");
				}

				using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

				try
				{
					_context.OrderItems.Remove(orderItem);

					var order = orderItem.Order;

					if(order is not null)
					{
						if(orderItem.Product is not null && orderItem.Product.ProductDetail is not null)
						{
							order.Total -= orderItem.Product.ProductDetail.Price;
						}

						_context.Orders.Update(order);

						await _context.SaveChangesAsync(cancellationToken);

						await transaction.CommitAsync(cancellationToken);
					}

					return new OrderItemDeleteResponse() { Message = "Deleted" };
				}
				catch (Exception e)
				{
					await transaction.RollbackAsync(cancellationToken);
					throw new MediatorException(ExceptionType.Error, "Error while deleting", e);
				}


			}
		}
	}
}
