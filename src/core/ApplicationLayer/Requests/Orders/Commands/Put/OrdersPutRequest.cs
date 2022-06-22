namespace ApplicationLayer.Requests.Orders.Commands.Put
{
	using Exceptions;
	using CodeLists.OrderStatuses;
	using DomainLayer.Entities.Orders;
	using Interfaces;
	using MediatR;
	using Microsoft.EntityFrameworkCore;
	using Utils.Orders;

	public class OrdersPutRequest : IRequest<OrdersPutResponse>
	{
		public Guid UserId { get; set; }

		public class Handler : IRequestHandler<OrdersPutRequest, OrdersPutResponse>
		{
			private readonly IDbContext _dbContext;

			public Handler(IDbContext dbContext) => _dbContext = dbContext;

			public async Task<OrdersPutResponse> Handle(OrdersPutRequest request, CancellationToken cancellationToken)
			{
				var actual = await _dbContext.Orders.Where(x => x.UserId == request.UserId &&
					(x.OrderStatusId == OrderStatuses.New ||
					x.OrderStatusId == OrderStatuses.Created))
					.ToListAsync(cancellationToken);

				if (actual.Count > 0)
				{
					throw new CRUDException(ExceptionTypeEnum.Error, $"There aleready is unfinished order: {actual.First().OrderCode}");
				}

				var lastOrderCode = (await _dbContext.Orders.OrderBy(x => x.OrderCode).LastAsync(cancellationToken)).OrderCode;

				string code = "AAAAA00000";

				if (lastOrderCode is not null)
				{
					code = OrderUtils.GetOrderCode(lastOrderCode);
				}

				try
				{
					var status = await _dbContext.OrderStatuses.FirstAsync(x => x.Id == OrderStatuses.New, cancellationToken);
					var id = Guid.NewGuid();
					_dbContext.Orders.Add(new OrderEntity()
					{
						Id = id,
						OrderCode = code,
						UserId = request.UserId,
						Total = 0,
						Status = status!
					});

					await _dbContext.SaveChangesAsync(cancellationToken);

					return new OrdersPutResponse { OrderCode = code, Message = "Order created", OrderId = id };
				}
				catch (Exception e)
				{
					throw new CRUDException(ExceptionTypeEnum.Error, "Error while creating order", e);
				}
			}
		}
	}
}
