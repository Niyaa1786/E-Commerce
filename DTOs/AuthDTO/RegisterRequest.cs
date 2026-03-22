using E_Commerce.Models.Carts;
using E_Commerce.Models.Orders;

namespace E_Commerce.DTOs.AuthDTO
{
    public class RegisterRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
