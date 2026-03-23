using E_Commerce.Models.Categories;

namespace E_Commerce.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCateogry(int id);
    }
}
