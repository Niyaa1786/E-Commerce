using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
