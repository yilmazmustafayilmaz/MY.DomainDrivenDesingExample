﻿using Domain.Abstraction;
using Domain.Shared;

namespace Domain.Orders;

public sealed class Order : Entity
{
    private Order(Guid id) : base(id)
    {

    }
    public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
    {
        OrderNumber = orderNumber;
        CreatedDate = createdDate;
        Status = status;
    }

    public string OrderNumber { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public OrderStatusEnum Status { get; private set; }

    public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

    public void CreateOrder(List<CreateOrderDto> createOrderDtos)
    {
        foreach (var item in createOrderDtos)
        {
            if (item.Quantity < 1)
                throw new ArgumentException("Sipariş adedi 1'den küçük olamaz");

            OrderLine orderLine = new(
                Guid.NewGuid(),
                Id,
                item.ProductId,
                item.Quantity,
                new(item.Amount, Currency.FromCode(item.Currency)));

            OrderLines.Add(orderLine);
        }
    }

    public void RemoveOrderLine(Guid orderLineId)
    {
        var orderLine = OrderLines.FirstOrDefault(x => x.Id == orderLineId);
        if (orderLine != null)
            throw new ArgumentException("Sipariş kalemi bulunamadı");
        OrderLines.Remove(orderLine);
    }
}