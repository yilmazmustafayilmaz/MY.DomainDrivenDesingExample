using Domain.Orders;
using MediatR;

namespace Application.UseCase.Orders.GetAllOrder;

public sealed record GetAllOrderQuery() : IRequest<List<Order>>;

internal sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllAsync(cancellationToken);
    }
}
