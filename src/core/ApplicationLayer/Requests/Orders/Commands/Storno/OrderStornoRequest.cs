using MediatR;
using PersistanceLayer.Contracts.Repositories;

namespace ApplicationLayer.Requests.Orders.Commands.Storno
{
	public class OrderStornoRequest : IRequest<OrderStornoResponse>
	{
		public string OrderCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderStornoRequest, OrderStornoResponse>
		{
			private readonly IOrdersRepository _repo;

			public Handler(IOrdersRepository repo) => _repo = repo ?? throw new ArgumentNullException(nameof(repo));

			public async Task<OrderStornoResponse> Handle(OrderStornoRequest request, CancellationToken cancellationToken)
			{
				await _repo.StornoOrderAsync(request.UserId, request.OrderCode, cancellationToken);

				return new() { Message = "Order canceled" };
			}
		}
	}
}
