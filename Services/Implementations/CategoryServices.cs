using Azure.Core;
using E_Commerce.Data;
using E_Commerce.DTOs.CategoryDTO;
using E_Commerce.Models.Categories;
using E_Commerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDbContext _db;
        public CategoryServices(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddCategory(CategoryRequest request)
        {
            try
            {
                var category = new Category { Name = request.Name };
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }

        public async Task<bool> DeleteCateogry(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null) return false;

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategories()
        {
            return await _db.Categories
            .Include(c => c.Products)
            .Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = DateTime.UtcNow
            }).ToListAsync();
        }

        public async Task<CategoryResponse?> GetCategoryByIdAsync(int id)
        {
            var category = await _db.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return null;

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<bool> UpdateCategory(int id, CategoryRequest request)
        {
            try
            {
                var category = await _db.Categories.FindAsync(id);
                if (category == null) return false;

                category.Name = request.Name;
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
            }
            catch { return false; }
            return true;
        }
    }
}
