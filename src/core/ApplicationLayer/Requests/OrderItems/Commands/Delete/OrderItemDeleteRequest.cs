using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.OrderItems.Commands.Delete
{
	public class OrderItemDeleteRequest : IRequest<OrderItemDeleteResponse>
	{
		public string OrderCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemDeleteRequest, OrderItemDeleteResponse>
		{
			private readonly IOrderItemsRepository _repo;

			public Handler(IOrderItemsRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<OrderItemDeleteResponse> Handle(OrderItemDeleteRequest request, CancellationToken cancellationToken)
			{
				await _repo.PutOrderItemAsync(request.OrderCode, request.ProductCode, request.UserId, cancellationToken);
				return new OrderItemDeleteResponse() { Message = "Deleted" };

			}
		}
	}
}
