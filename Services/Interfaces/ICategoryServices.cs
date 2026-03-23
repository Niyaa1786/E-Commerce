using E_Commerce.DTOs.CategoryDTO;
using E_Commerce.Models.Categories;

namespace E_Commerce.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse?> GetCategoryByIdAsync(int id);
        Task<bool> AddCategory(CategoryRequest request);
        Task<bool> UpdateCategory(int id, CategoryRequest request);
        Task<bool> DeleteCateogry(int id);
    }
}
