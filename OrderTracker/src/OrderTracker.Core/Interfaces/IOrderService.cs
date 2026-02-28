using OrderTracker.Core.Entities;
using OrderTracker.Core.Enums;

namespace OrderTracker.Core.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> Search(string query);
    Order GetById(Guid id);
    void AddNote(Guid id, string author, string message);
    void UpdateStatus(Guid id, OrderStatus newStatus);
}