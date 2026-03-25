using E_Commerce.Data;
using E_Commerce.Models.Enums;
using E_Commerce.Models.Orders;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _db;
        public OrderServices(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _db.Orders.ToListAsync();  
        }

        public async Task<IEnumerable<OrderItem>> GetOrderDetail(int id)
        {
            return await _db.OrderItems.Where(oi => oi.OrderId == id ).ToListAsync();
        }

        public async Task<bool> PlaceOrder(int id, string address)
        {
            var cart = await _db.Carts.Include(ci => ci.Items!)
                                      .ThenInclude(i => i.ProductVarient)
                                      .FirstOrDefaultAsync(c => c.UserId == id);

            if (cart == null || !cart.Items!.Any()) return false;

            var order = new Order
            {
                UserId = id,
                ShippingAddress = address,
                Status = OrderStatus.Pending.ToString(),
                TotalAmount = cart.Items!.Sum(i => i.Quantity * i.ProductVarient!.Price),
                OrderItems = cart.Items!.Select(i => new OrderItem
                {
                    ProductVarient = i.ProductVarient,
                    Quantity = i.Quantity,
                    UnitPrice = i.ProductVarient!.Price 
                }).ToList()
            };

            _db.Orders.Add(order);
            _db.CartItems.RemoveRange(cart.Items);

            await _db.SaveChangesAsync();
            return true;

        }
    }
}
