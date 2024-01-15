using Domain.Orders;
using MediatR;

namespace Application.UseCase.Orders.CreateOrder;

public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;
