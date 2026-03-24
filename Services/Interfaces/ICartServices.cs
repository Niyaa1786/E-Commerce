using E_Commerce.DTOs.CartDTO;

namespace E_Commerce.Services.Interfaces
{
    public interface ICartServices
    {
        public Task<bool> AddToCart(int id, AddToCartRequest request);
        public Task<bool> RemoveFromCart(int id);
        public Task<IEnumerable<CartItemResponse>> GetUserCart(int id);

    }
}
