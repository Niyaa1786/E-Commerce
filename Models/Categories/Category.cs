using E_Commerce.Models.Products;

namespace E_Commerce.Models.Categories
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
