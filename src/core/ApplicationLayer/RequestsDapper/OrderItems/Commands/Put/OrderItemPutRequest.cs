using System.Data.SqlClient;
using ApplicationLayer.Exceptions;
using CodeLists.Exceptions;
using MediatR;
using PersistanceLayerDapper;
using PersistanceLayerDapper.Extensions;

namespace ApplicationLayer.RequestsDapper.OrderItems.Commands.Put
{
	public class OrderItemPutRequest : IRequest<OrderItemPutResponse>
	{
		public string ProductCode { get; set; } = string.Empty;
		public string OrderCode { get; set; } = string.Empty;
		public int UserId { get; set; }

		public class Handler : IRequestHandler<OrderItemPutRequest, OrderItemPutResponse>
		{
			private readonly DapperContext _context;

			public Handler(DapperContext dbContext) => _context = dbContext;

			public async Task<OrderItemPutResponse> Handle(OrderItemPutRequest request, CancellationToken cancellationToken)
			{
				try
				{
					await _context.ExecuteProcedureAsync("[dbo].[PutOrderItemToOrder]", CreatePutOrderItemProcedureParameters(request));

					return new OrderItemPutResponse()
					{
						Message = "Added"
					};
				}
				catch (SqlException ex)
				{
					if (ex.Number == 51000)
					{
						throw new MediatorException(ExceptionType.NotFound, ex.Message);
					}

					throw new MediatorException(ExceptionType.Error, "Product addition to order failed", ex);
				}
				catch (Exception e)
				{
					throw new MediatorException(ExceptionType.Error, "Product addition to order failed", e);
				}
			}

			private static object CreatePutOrderItemProcedureParameters(OrderItemPutRequest request)
			{
				return new { request.OrderCode, request.ProductCode, request.UserId };
			}
		}
	}
}
