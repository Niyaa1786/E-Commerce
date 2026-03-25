using E_Commerce.Models.Orders;

namespace E_Commerce.Services.Interfaces
{
    public interface IOrderServices
    {
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<IEnumerable<OrderItem>> GetOrderDetail(int id);
        public Task<bool> PlaceOrder(int id, string address);
    }
}
