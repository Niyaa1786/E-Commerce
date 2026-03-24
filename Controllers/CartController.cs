using E_Commerce.DTOs.CartDTO;
using E_Commerce.Services.Implementations;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var cartItems = await _cartServices.GetUserCart(userId);
            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _cartServices.AddToCart(userId, request);

            if (result) return RedirectToAction(nameof(Index));
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _cartServices.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
