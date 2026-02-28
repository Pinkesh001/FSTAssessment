using OrderTracker.Core.Entities;
using OrderTracker.Core.Enums;
using OrderTracker.Core.Exceptions;
using OrderTracker.Core.Interfaces;

namespace OrderTracker.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    
    public OrderService(IOrderRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Order> Search(string query)
    {
        
        return _repo.GetAll().Where(o =>
            o.Id.ToString() == query ||
            o.Email.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            o.Mobile.Contains(query));
    }

    public Order GetById(Guid id)
    {
        var order = _repo.Get(id);
        if (order == null)
            throw new NotFoundException("Order not found");

        return order;
    }

    public void AddNote(Guid id, string author, string message)
    {
        if (message.Length > 500)
            throw new ValidationException("Note cannot exceed 500 characters");

        var order = GetById(id);

        order.Notes.Add(new OrderNote
        {
            Author = author,
            Message = message,
            CreatedAt = DateTime.UtcNow
        });

        _repo.Update(order);
    }

    public void UpdateStatus(Guid id, OrderStatus newStatus)
    {
        var order = GetById(id);

        if (!IsValidTransition(order.Status, newStatus))
            throw new ValidationException("Invalid status transition");

        order.Status = newStatus;
        order.Timeline.Add(new OrderTimeline
        {
            Status = newStatus,
            Timestamp = DateTime.UtcNow
        });

        _repo.Update(order);
        
    }

    private bool IsValidTransition(OrderStatus current, OrderStatus next)
    {
        if (current == OrderStatus.DELIVERED)
            return false;

        return current switch
        {
            OrderStatus.PLACED => next == OrderStatus.PAID || next == OrderStatus.CANCELLED,
            OrderStatus.PAID => next == OrderStatus.SHIPPED || next == OrderStatus.CANCELLED,
            OrderStatus.SHIPPED => next == OrderStatus.DELIVERED || next == OrderStatus.CANCELLED,
            _ => false
        };
    }
}