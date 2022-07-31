namespace ApplicationLayer.Requests.Orders.Commands.ChangeStatus
{
	using Exceptions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class OrderChangeStatusRequest : IRequest<OrderChangeStatusResponse>
	{
		public int UserId { get; set; }
		public string OrderCode { get; set; } = string.Empty;
		public int StatusId { get; set; }

		public class Handler : IRequestHandler<OrderChangeStatusRequest, OrderChangeStatusResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<OrderChangeStatusResponse> Handle(OrderChangeStatusRequest request, CancellationToken cancellationToken)
			{
				var actual = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderCode == request.OrderCode, cancellationToken);

				if (actual is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Order not found");
				}

				if (actual.UserId != request.UserId)
				{
					throw new MediatorException(ExceptionType.Unauthorized, "Wrong user");
				}

				var status = await _dbContext.OrderStatuses.FirstOrDefaultAsync(x => x.Id == request.StatusId, cancellationToken);

				if(status is null)
				{
					throw new MediatorException(ExceptionType.NotFound, "Status not found");
				}

				if (status.Id - 1 != actual.OrderStatusId )
				{
					throw new MediatorException(ExceptionType.NotModified, "Status cant be replaced by provided value");
				}

				actual.Status = status;

				try
				{
					_dbContext.Orders.Update(actual);
					await _dbContext.SaveChangesAsync(cancellationToken);

					return new OrderChangeStatusResponse { Message = "Status changed" };
				}
				catch (Exception ex)
				{
					throw new MediatorException(ExceptionType.Error, "Error while changing status", ex);
				}
			}
		}
	}
}
