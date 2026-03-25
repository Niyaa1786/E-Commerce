using E_Commerce.Models.Orders;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(string shippingAddress)
        {
            if (string.IsNullOrEmpty(shippingAddress))
            {
                ModelState.AddModelError("", "Vui lòng nhập địa chỉ giao hàng");
                return View();
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            if (userId == null) return Unauthorized();

            var result = await _orderServices.PlaceOrder(userId, shippingAddress);

            if (result)
            {
                TempData["Success"] = "Đặt hàng thành công!";

                return RedirectToAction("Index", "Home");
            }
            return BadRequest("Giỏ hàng trống");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServices.GetAllOrders();

            if (orders == null)
            {
                orders = new List<Order>();
            }

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetail(int id)
        {

            var order = await _orderServices.GetOrderDetail(id);
            if (order == null) return NotFound();

            return View(order);
        }
    }
}
