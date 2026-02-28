using OrderTracker.Core.Entities;
using OrderTracker.Core.Enums;

namespace OrderTracker.Infrastructure.Data;

public static class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Orders.Any())
            return;

        var order1 = new Order
        {
            Email = "john.doe@gmail.com",
            Mobile = "9999999999",
            Status = OrderStatus.PLACED
        };

        order1.Timeline.Add(new OrderTimeline
        {
            Status = OrderStatus.PLACED,
            Timestamp = DateTime.UtcNow
        });

        var order2 = new Order
        {
            Email = "jane.smith@gmail.com",
            Mobile = "8888888888",
            Status = OrderStatus.SHIPPED
        };

        order2.Timeline.Add(new OrderTimeline
        {
            Status = OrderStatus.PLACED,
            Timestamp = DateTime.UtcNow.AddHours(-5)
        });

        order2.Timeline.Add(new OrderTimeline
        {
            Status = OrderStatus.PAID,
            Timestamp = DateTime.UtcNow.AddHours(-4)
        });

        order2.Timeline.Add(new OrderTimeline
        {
            Status = OrderStatus.SHIPPED,
            Timestamp = DateTime.UtcNow.AddHours(-2)
        });

        context.Orders.AddRange(order1, order2);
        context.SaveChanges();
    }
}