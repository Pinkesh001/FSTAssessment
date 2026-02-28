using OrderTracker.Core.Enums;

namespace OrderTracker.Core.Entities;

public class OrderTimeline
{
    public Guid Id { get; set; } = Guid.NewGuid();   // ✅ Primary Key

    public OrderStatus Status { get; set; }
    public DateTime Timestamp { get; set; }
}