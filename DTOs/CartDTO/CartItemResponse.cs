namespace E_Commerce.DTOs.CartDTO
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Color { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }
        public decimal SubTotal => Price * Quantity;
    }
}
