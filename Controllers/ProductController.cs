using E_Commerce.DTOs.ProductDTO;
using E_Commerce.Models.Products;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productService;
        private readonly ICategoryServices _categoryService;

        public ProductController(IProductServices productService, ICategoryServices categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var result = await _productService.AddProduct(request);
            if (result)
            {
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Lỗi khi lưu sản phẩm.");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            var categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            var request = new UpdateProductRequest
            {
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                ProductVarients = product.ProductVarients?.Select(v => new ProductVariantRequest
                {
                    Id = v.Id,
                    SKU = v.SKU,
                    Price = v.Price,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var result = await _productService.UpdateProduct(id, request);
            if (result)
            {
                TempData["Success"] = "Cập nhật thành công!";
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result) TempData["Success"] = "Xóa thành công.";
            else TempData["Error"] = "Xóa thất bại.";

            return RedirectToAction(nameof(Index));
        }
    }
}