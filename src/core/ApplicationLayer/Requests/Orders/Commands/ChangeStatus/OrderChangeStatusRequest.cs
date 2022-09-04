namespace ApplicationLayer.Requests.Orders.Commands.ChangeStatus
{
	using MediatR;
	using PersistanceLayer.Contracts.Repositories;

	public class OrderChangeStatusRequest : IRequest<OrderChangeStatusResponse>
	{
		public int UserId { get; set; }
		public string OrderCode { get; set; } = string.Empty;
		public int StatusId { get; set; }

		public class Handler : IRequestHandler<OrderChangeStatusRequest, OrderChangeStatusResponse>
		{
			private readonly IOrdersRepository _repo;

			public Handler(IOrdersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<OrderChangeStatusResponse> Handle(OrderChangeStatusRequest request, CancellationToken cancellationToken)
			{
				await _repo.OrderChangeStatusAsync(request.OrderCode, request.StatusId, request.UserId, cancellationToken);
				return new OrderChangeStatusResponse { Message = "Status changed" };
			}
		}
	}
}
