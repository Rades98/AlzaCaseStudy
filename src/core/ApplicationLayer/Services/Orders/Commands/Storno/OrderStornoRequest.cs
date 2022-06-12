namespace ApplicationLayer.Services.Orders.Commands.Storno
{
    using Exceptions;
    using Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrderStornoRequest : IRequest<OrderStornoResponse>
    {
        public string OrderCode { get; set; } = string.Empty;
        public Guid UserId { get; set; }

        public class Handler : IRequestHandler<OrderStornoRequest, OrderStornoResponse>
        {
            private readonly IDbContext _context;

            public Handler(IDbContext context) => _context = context;

            public async Task<OrderStornoResponse> Handle(OrderStornoRequest request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                    .Include(i => i.Status)
                    .Include(i => i.Items)
                        .ThenInclude(i => i.Product)
                            .ThenInclude(i => i.ProductDetail)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                    x.UserId == request.UserId &&
                    x.OrderCode == request.OrderCode
                , cancellationToken);

                if (order is null)
                {
                    throw new CRUDException(ExceptionTypeEnum.NotFound, "Order not found");
                }

                if (order.OrderStatusId == CodeLists.OrderStatuses.OrderStatuses.Canceled ||
                    order.OrderStatusId == CodeLists.OrderStatuses.OrderStatuses.Delivered ||
                    order.OrderStatusId == CodeLists.OrderStatuses.OrderStatuses.InExpedition)
                {
                    throw new CRUDException(ExceptionTypeEnum.Error, "Order cannot be cancelled");
                }

                using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

                try
                {
                    order.Status = await _context.OrderStatuses
                        .AsNoTracking()
                        .FirstAsync(x => x.Id == CodeLists.OrderStatuses.OrderStatuses.Canceled, cancellationToken);
                    order.OrderStatusId = CodeLists.OrderStatuses.OrderStatuses.Canceled;

                    if (order.Items is not null)
                    {
                        _context.OrderItems.RemoveRange(order.Items);
                        order.Items.Clear();
                    }

                    _context.Orders.Update(order);

                    await _context.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                    return new() { Message = "Order canceled" };
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw new CRUDException(ExceptionTypeEnum.Error, "Error while canceling order", e);
                }
            }
        }
    }
}
