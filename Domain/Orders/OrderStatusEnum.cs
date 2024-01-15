namespace Domain.Orders;

public enum OrderStatusEnum
{
    AwatingApproval = 1,
    BeingPrepared = 2,
    InTransit = 3,
    Delivered = 4,
}