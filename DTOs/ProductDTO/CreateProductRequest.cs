namespace E_Commerce.DTOs.ProductDTO
{
    public class CreateProductRequest
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public List<ProductVariantRequest>? Variants { get; set; }
        public string? ImageUrl { get; set; }

    }
}
