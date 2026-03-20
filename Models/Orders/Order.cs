using E_Commerce.Models.Enums;
using E_Commerce.Models.Users;

namespace E_Commerce.Models.Orders
{
    public class Order :AuditableEntity
    {
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; } = OrderStatus.Pending.ToString();
        public string? ShippingAddress { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
