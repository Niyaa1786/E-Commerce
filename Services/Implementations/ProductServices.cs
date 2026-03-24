using Azure.Core;
using E_Commerce.Data;
using E_Commerce.DTOs.ProductDTO;
using E_Commerce.Models.Products;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace E_Commerce.Services.Implementations
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _db;
        public ProductServices(AppDbContext context)
        {
            _db = context;
        }

        public async Task<bool> AddProduct(CreateProductRequest productRequest)
        {
            try
            {
                var product = new Product
                {
                    Name = productRequest.Name,
                    CategoryId = productRequest.CategoryId,
                    Description = productRequest.Description,
                    ImageUrl = productRequest.ImageUrl,

                    ProductVarients = productRequest.Variants!.Select(v => new ProductVarient
                        {
                            SKU = v.SKU,
                            Price = v.Price,
                            Color = v.Color,
                            Size = v.Size,
                            Quantity = v.Quantity
                        }).ToList()
                };

                _db.Add(product);
                await _db.SaveChangesAsync();
                return true;
            }catch{ return false; }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var isExisting = await _db.Products.FindAsync(id);
            if(isExisting is null) { return false; }
            _db.Products.Remove(isExisting);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _db.Products.Include(p => p.ProductVarients).Include(c => c.Category).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _db.Products.Include(p => p.ProductVarients).Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);
            return product!;
        }

        public async Task<Product> GetProductByName(string name)
        {
            var product = await _db.Products.Where(p => p.Name!.Contains(name,StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();
            return product!;
        }
        
        public async Task<bool> UpdateProduct(int id, UpdateProductRequest product)
        {
            try
            {
                var existingProduct = await _db.Products.Include(p => p.ProductVarients).FirstOrDefaultAsync(p => p.Id == id);

                if (existingProduct is null) return false;
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.ImageUrl = product.ImageUrl;

                foreach (var varientReq in product.ProductVarients!)
                {
                    var existingVarient = existingProduct.ProductVarients!.FirstOrDefault(v => v.Id == varientReq.Id);
                    if(existingVarient is not null)
                    {
                        existingVarient.SKU = varientReq.SKU;
                        existingVarient.Quantity = varientReq.Quantity;
                        existingVarient.Price = varientReq.Price;
                        existingVarient.Color = varientReq.Color;
                        existingVarient.Size = varientReq.Size;
                    }else
                    {
                        existingProduct.ProductVarients!.Add(new ProductVarient
                        {
                            SKU = varientReq.SKU,
                            Quantity = varientReq.Quantity,
                            Price = varientReq.Price,
                            Color = varientReq.Color,
                            Size = varientReq.Size,
                        });
                    }
                }
                await _db.SaveChangesAsync();
                return true;

            }
            catch { return false; }

        }
    }
}
