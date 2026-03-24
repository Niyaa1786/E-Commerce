using E_Commerce.Models.Categories;
using E_Commerce.Models.Products;

namespace E_Commerce.DTOs.ProductDTO
{
    public class UpdateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }


        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductVariantRequest>? ProductVarients { get; set; }
    }
}
