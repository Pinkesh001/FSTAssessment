using OrderTracker.Core.Enums;

namespace Orderops.api.Models;

public class UpdateStatusRequest
{
    public OrderStatus Status { get; set; }
}