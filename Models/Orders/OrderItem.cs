using E_Commerce.Models.Products;

namespace E_Commerce.Models.Orders
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public int ProductVarientId { get; set; }
        public Order? Order { get; set; }
        public ProductVarient? ProductVarient { get; set;}
    }
}
