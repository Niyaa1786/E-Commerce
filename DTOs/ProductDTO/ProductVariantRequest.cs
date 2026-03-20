namespace E_Commerce.DTOs.ProductDTO
{
    public class ProductVariantRequest
    {
        public int Id { get; set; }
        public string? SKU { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
