namespace ApplicationLayer.RequestsDapper.OrderItems.Commands.Put
{
	using System.Data.SqlClient;
	using System.Threading;
	using System.Threading.Tasks;
	using Exceptions;
	using MediatR;
	using PersistanceLayerDapper;
	using PersistanceLayerDapper.Extensions;

	public class OrderItemPutRequest : IRequest<OrderItemPutResponse>
	{
		public string ProductCode { get; set; } = string.Empty;
		public string OrderCode { get; set; } = string.Empty;
		public Guid UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemPutRequest, OrderItemPutResponse>
		{
			private readonly DapperContext _context;

			public Handler(DapperContext dbContext) => _context = dbContext;

			public async Task<OrderItemPutResponse> Handle(OrderItemPutRequest request, CancellationToken cancellationToken)
			{
				try
				{
					var result = await _context.ExecuteProcedureAsync("[dbo].[PutOrderItemToOrder]", CreatePutOrderItemProcedureParameters(request));

					return new OrderItemPutResponse()
					{
						Message = "Added"
					};
				}
				catch (SqlException ex)
				{
					if (ex.Number == 51000)
					{
						throw new CRUDException(ExceptionTypeEnum.NotFound, ex.Message);
					}

					throw new CRUDException(ExceptionTypeEnum.Error, "Product addition to order failed", ex);
				}
				catch (Exception e)
				{
					throw new CRUDException(ExceptionTypeEnum.Error, "Product addition to order failed", e);
				}
			}

			private object CreatePutOrderItemProcedureParameters(OrderItemPutRequest request)
			{
				return new { request.OrderCode, request.ProductCode, request.UserId };
			}
		}
	}
}
