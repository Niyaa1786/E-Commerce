using E_Commerce.Models.Carts;
using E_Commerce.Models.Orders;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs.AuthDTO
{
    public class RegisterRequest
    {
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
