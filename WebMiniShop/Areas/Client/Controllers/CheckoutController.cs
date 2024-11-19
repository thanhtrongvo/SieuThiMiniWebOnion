using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
