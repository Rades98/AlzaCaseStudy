namespace ApplicationLayer.Requests.Orders.Queries
{
	using System.Linq.Expressions;
	using DomainLayer.Entities.Orders;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class OrdersGetByUserRequest : IRequest<List<OrdersGetResponse>>
	{
		public int UserId { get; set; }
		public Expression<Func<OrderEntity, bool>> WhereFilter { get; set; } = x => true;

		public class Handler : IRequestHandler<OrdersGetByUserRequest, List<OrdersGetResponse>>
		{
			private readonly IOrdersRepository _repo;

			public Handler(IOrdersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<List<OrdersGetResponse>> Handle(OrdersGetByUserRequest request, CancellationToken cancellationToken)
			{
				var result = new List<OrdersGetResponse>();

				var orders = await _repo.GetOrdersByUserId(request.UserId, request.WhereFilter, cancellationToken);

				orders.ForEach(order =>
				{
					var response = new OrdersGetResponse
					{
						OrderCode = order.OrderCode,
						Total = order.Total,
						OrderStatus = order.OrderStatusId
					};

					order.OrderItems.ForEach(item =>
					{
						response.OrderItems.Add(new Dtos.OrderItemDto
						{
							Name = item.Name,
							Price = item.Price,
							ProductCode = item.ProductCode,
							Count = item.Count
						});
					});

					result.Add(response);
				});

				return result;
			}
		}
	}
}
