using E_Commerce.Models.Carts;
using E_Commerce.Models.Orders;

namespace E_Commerce.Models.Users
{
    public class User :AuditableEntity
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public string Role { get; set; } = "Client";


        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
