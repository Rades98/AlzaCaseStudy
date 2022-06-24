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
						.ThenInclude(i => i.Status)
					.Include(i => i.Product)
						.ThenInclude(i => i.ProductDetail)
					.AsNoTracking()
					.FirstOrDefaultAsync(x =>
					x.Product.ProductDetail.ProductCode == request.ProductCode &&
					x.Order.OrderCode == request.OrderCode &&
					x.Order.UserId == request.UserId
					, cancellationToken);

				if (orderItem is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Order item not found");
				}

				using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

				try
				{
					_context.OrderItems.Remove(orderItem);

					var order = orderItem.Order;
					order.Total -= orderItem.Product.ProductDetail.Price;

					_context.Orders.Update(order);

					await _context.SaveChangesAsync(cancellationToken);

					await transaction.CommitAsync(cancellationToken);

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
