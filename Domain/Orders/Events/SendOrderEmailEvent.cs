using MediatR;

namespace Domain.Orders.Events;

public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönderme
        return Task.CompletedTask;
    }
}
