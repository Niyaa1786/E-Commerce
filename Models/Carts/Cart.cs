using E_Commerce.Models.Users;

namespace E_Commerce.Models.Carts
{
    public class Cart :AuditableEntity
    {
        public int UserId { get; set; }
        
        public User? User { get; set; }
        public ICollection<CartItem>? Items { get; set; }
    }
}
