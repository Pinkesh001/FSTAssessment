using OrderTracker.Core.Entities;

namespace OrderTracker.Core.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order? Get(Guid id);
    void Update(Order order);
    void Add(Order order);
}