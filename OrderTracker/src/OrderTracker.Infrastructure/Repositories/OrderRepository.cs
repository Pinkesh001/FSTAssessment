using OrderTracker.Core.Entities;
using OrderTracker.Core.Interfaces;
using OrderTracker.Infrastructure.Data;

namespace OrderTracker.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAll() => _context.Orders.ToList();

    public Order? Get(Guid id) =>
        _context.Orders.FirstOrDefault(o => o.Id == id);

    public void Update(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}