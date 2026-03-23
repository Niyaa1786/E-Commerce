using E_Commerce.DTOs.CategoryDTO;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _categoryServices.AddCategory(request);
            if (result)
            {
                TempData["Success"] = "Thêm danh mục mới thành công!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Có lỗi xảy ra khi lưu dữ liệu.");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            var request = new CategoryRequest { Name = category.Name };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _categoryServices.UpdateCategory(id, request);
            if (result)
            {
                TempData["Success"] = "Cập nhật danh mục thành công!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Không tìm thấy danh mục hoặc cập nhật thất bại.");
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryServices.DeleteCateogry(id);
            if (result)
            {
                TempData["Success"] = "Đã xóa danh mục thành công.";
            }
            else
            {
                TempData["Error"] = "Xóa thất bại, vui lòng kiểm tra lại.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}