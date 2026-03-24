using E_Commerce.Data;
using E_Commerce.DTOs.CartDTO;
using E_Commerce.Models.Carts;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services.Implementations
{
    public class CartServices : ICartServices
    {
    private readonly AppDbContext _db;
    public CartServices(AppDbContext db) => _db = db;

    public async Task<bool> AddToCart(int userId, AddToCartRequest request)
    {
        var cart = await _db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();
        }

        var existingItem = cart.Items?
            .FirstOrDefault(i => i.ProductVarientId == request.ProductVarientId);

        if (existingItem != null)
        {
            existingItem.Quantity += request.Quantity;
        }
        else
        {
            if (cart.Items == null) cart.Items = new List<CartItem>();
            cart.Items.Add(new CartItem
            {
                ProductVarientId = request.ProductVarientId,
                Quantity = request.Quantity
            });
        }

        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<CartItemResponse>> GetUserCart(int userId)
    {
        return await _db.CartItems
            .Where(ci => ci.Cart!.UserId == userId)
            .Select(ci => new CartItemResponse
            {
                Id = ci.Id,
                ProductName = ci.ProductVarient!.Product!.Name,
                Color = ci.ProductVarient.Color,
                Size = ci.ProductVarient.Size,
                Price = ci.ProductVarient.Price,
                Quantity = ci.Quantity,
                ImageUrl = ci.ProductVarient.Product.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<bool> RemoveFromCart(int cartItemId)
    {
        var item = await _db.CartItems.FindAsync(cartItemId);
        if (item == null) return false;

        _db.CartItems.Remove(item);
        await _db.SaveChangesAsync();
        return true;
    }
    }
}
