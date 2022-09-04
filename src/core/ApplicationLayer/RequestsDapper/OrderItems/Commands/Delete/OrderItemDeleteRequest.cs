namespace ApplicationLayer.RequestsDapper.OrderItems.Commands.Delete
{
	using System.Threading;
	using System.Threading.Tasks;
	using Exceptions;
	using MediatR;
	using System.Data.SqlClient;
	using PersistanceLayerDapper;
	using PersistanceLayerDapper.Extensions;
	using CodeLists.Exceptions;

	public class OrderItemDeleteRequest : IRequest<OrderItemDeleteResponse>
	{
		public string OrderCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemDeleteRequest, OrderItemDeleteResponse>
		{
			private readonly DapperContext _context;

			public Handler(DapperContext context) => _context = context;

			public async Task<OrderItemDeleteResponse> Handle(OrderItemDeleteRequest request, CancellationToken cancellationToken)
			{
				try
				{
					await _context.ExecuteProcedureAsync("[dbo].[DeleteOrderItem]", CreateDeleteOrderItemProcedureParameters(request));

					return new OrderItemDeleteResponse()
					{
						Message = "Deleted"
					};
				}
				catch (SqlException ex)
				{
					if (ex.Number == 51000)
					{
						throw new MediatorException(ExceptionType.NotFound, ex.Message);
					}

					throw new MediatorException(ExceptionType.Error, "Error while deleting", ex);
				}
				catch (Exception e)
				{
					throw new MediatorException(ExceptionType.Error, "Error while deleting", e);
				}
			}

			private static object CreateDeleteOrderItemProcedureParameters(OrderItemDeleteRequest request)
			{
				return new { request.OrderCode, request.ProductCode, request.UserId };
			}
		}
	}
}
