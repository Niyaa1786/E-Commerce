using E_Commerce.Models.Carts;
using E_Commerce.Models.Orders;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Models.Users
{
    public class User : IdentityUser<int>
    {
        public string? FullName { get; set; }

        public bool IsActive { get; set; } = true;
        public string Role { get; set; } = "Client";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt {  get; set; }


        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
