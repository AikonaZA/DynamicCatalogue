namespace Ordering.Data.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string UserId { get; set; }  // Assuming integration with Identity
    public ICollection<OrderItem> OrderItems { get; set; }
    public decimal TotalAmount { get; set; }
}