using E_Commerce.Models;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productService;

        // Inject ProductService để lấy dữ liệu sản phẩm
        public HomeController(IProductServices productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult InProgress()
        {
            return View();
        }
    }
}
