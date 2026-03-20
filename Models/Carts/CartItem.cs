using E_Commerce.Models.Products;

namespace E_Commerce.Models.Carts
{
    public class CartItem :BaseEntity
    {
        public int Quantity { get; set; }

        public int CartId { get; set; }
        public int ProductVarientId { get; set; }
        public Cart? Cart { get; set; }
        public ProductVarient? ProductVarient { get; set; }
    }
}
