﻿namespace ApplicationLayer.Requests.Orders.Commands.ChangeStatus
{
	using Exceptions;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;

	public class OrderChangeStatusRequest : IRequest<OrderChangeStatusResponse>
	{
		public Guid UserId { get; set; }
		public string OrderCode { get; set; } = string.Empty;
		public Guid StatusId { get; set; }

		public class Handler : IRequestHandler<OrderChangeStatusRequest, OrderChangeStatusResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<OrderChangeStatusResponse> Handle(OrderChangeStatusRequest request, CancellationToken cancellationToken)
			{
				var actual = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderCode == request.OrderCode, cancellationToken);

				if (actual is null)
				{
					throw new CRUDException(ExceptionTypeEnum.NotFound, "Order not found");
				}

				if (actual.UserId != request.UserId)
				{
					throw new CRUDException(ExceptionTypeEnum.Unauthorized, "Wrong user");
				}

				actual.OrderStatusId = request.StatusId;

				try
				{
					_dbContext.Orders.Update(actual);
					await _dbContext.SaveChangesAsync(cancellationToken);

					return new OrderChangeStatusResponse { Message = "Status changed" };
				}
				catch (Exception ex)
				{
					throw new CRUDException(ExceptionTypeEnum.Error, "Error while changing status", ex);
				}
			}
		}
	}
}