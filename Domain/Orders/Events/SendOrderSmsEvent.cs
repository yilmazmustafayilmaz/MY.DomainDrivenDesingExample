using MediatR;

namespace Domain.Orders.Events;

public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //SMS gönderme
        return Task.CompletedTask;
    }
}
