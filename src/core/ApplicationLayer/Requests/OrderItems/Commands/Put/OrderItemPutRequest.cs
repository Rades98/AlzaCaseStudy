namespace ApplicationLayer.Requests.OrderItems.Commands.Put
{
	using System.Threading;
	using System.Threading.Tasks;
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class OrderItemPutRequest : IRequest<OrderItemPutResponse>
	{
		public string ProductCode { get; set; } = string.Empty;
		public string OrderCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemPutRequest, OrderItemPutResponse>
		{
			private readonly IOrderItemsRepository _repo;

			public Handler(IOrderItemsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<OrderItemPutResponse> Handle(OrderItemPutRequest request, CancellationToken cancellationToken)
			{
				await _repo.PutOrderItemAsync(request.OrderCode, request.ProductCode, request.UserId, cancellationToken);

				return new OrderItemPutResponse() { Message = "OK" };
			}
		}
	}
}
