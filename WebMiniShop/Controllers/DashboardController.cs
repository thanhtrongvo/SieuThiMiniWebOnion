using Microsoft.AspNetCore.Mvc;

namespace WebMiniShop.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
