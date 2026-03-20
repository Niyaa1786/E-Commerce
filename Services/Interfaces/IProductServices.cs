using E_Commerce.DTOs.ProductDTO;
using E_Commerce.Models.Products;

namespace E_Commerce.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task<bool> AddProduct(CreateProductRequest product);
        public Task<bool> UpdateProduct(int id, UpdateProductRequest product);
        public Task<bool> DeleteProduct(int id);
    }
}
