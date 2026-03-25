using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly IOrderServices _orderServices;

        public AdminHomeController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            // LẤY  THỰC TẾ Ở ĐÂY
            var orders = await _orderServices.GetAllOrders();

            return View(orders);
        }
    }
}
