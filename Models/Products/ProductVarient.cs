using E_Commerce.Models.Products;

namespace E_Commerce.Models.Products
{
    public class ProductVarient : AuditableEntity
    {
        public string? SKU { get; set; }
        public int Size { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } 

        public int ProductId { get; set; }

        public Product? Product { get; set; }


    }
}
