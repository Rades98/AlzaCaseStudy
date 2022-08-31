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

				foreach (var order in orders)
				{

					var response = new OrdersGetResponse
					{
						OrderCode = order.OrderCode,
						Total = order.Total,
					};

					if (order.Status is not null)
					{
						response.OrderStatus = order.Status.Id;
					}

					order.Items!.AsEnumerable().Where(p => p.Product != null && p.Product.ProductDetail != null).ToList().ForEach(p =>
					{
						var detail = p.Product!.ProductDetail!;

						var opt = response.OrderItems.FirstOrDefault(x => x.ProductCode == detail.ProductCode);

						if (opt is not null)
						{
							opt.Count++;
						}
						else
						{
							response.OrderItems.Add(new Dtos.OrderItemDto
							{
								Name = detail.Name,
								Price = detail.Price,
								ProductCode = detail.ProductCode,
								Count = 1
							});
						}

					});

					result.Add(response);
				}

				return result;
			}
		}
	}
}
