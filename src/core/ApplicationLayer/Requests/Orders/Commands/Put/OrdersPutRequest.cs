namespace ApplicationLayer.Requests.Orders.Commands.Put
{
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class OrdersPutRequest : IRequest<OrdersPutResponse>
	{
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrdersPutRequest, OrdersPutResponse>
		{
			private readonly IOrdersRepository _repo;

			public Handler(IOrdersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<OrdersPutResponse> Handle(OrdersPutRequest request, CancellationToken cancellationToken)
			{
				var code = await _repo.CreateOrderAsync(request.UserId, cancellationToken);
				return new OrdersPutResponse { OrderCode = code, Message = "Order created" };
			}
		}
	}
}
