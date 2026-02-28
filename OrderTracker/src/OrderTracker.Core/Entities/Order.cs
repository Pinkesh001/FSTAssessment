using OrderTracker.Core.Enums;

namespace OrderTracker.Core.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;

    public OrderStatus Status { get; set; } = OrderStatus.PLACED;

    public List<OrderNote> Notes { get; set; } = new();
    public List<OrderTimeline> Timeline { get; set; } = new();
}