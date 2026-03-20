namespace E_Commerce.DTOs.ProductDTO
{
    public class CreateProductRequest
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductVariantRequest>? Variants { get; set; }
    }
}
