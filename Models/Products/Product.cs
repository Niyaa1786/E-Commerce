using E_Commerce.Models.Categories;
using E_Commerce.Models.Products;

namespace E_Commerce.Models.Products
{
    public class Product : AuditableEntity
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductVarient>? ProductVarients { get; set; }
    }
}
