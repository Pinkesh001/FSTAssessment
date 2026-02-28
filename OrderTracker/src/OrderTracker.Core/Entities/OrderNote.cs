namespace OrderTracker.Core.Entities;

public class OrderNote
{
    public Guid Id { get; set; } = Guid.NewGuid();   // ✅ Primary Key

    public string Author { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}