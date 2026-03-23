using E_Commerce.DTOs.AuthDTO;
using E_Commerce.Services.Implementations;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            var result = await _authServices.Register(request);
            if (result)
            {
                TempData["Success"] = "Đăng ký thành công";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Email đã tồn tại hoặc mật khẩu chưa đủ mạnh.");
            return View(request);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var role = await _authServices.Login(request);
            if (role is not null )
            {
                if (role == "Admin") return RedirectToAction("Index","AdminHome");
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authServices.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
