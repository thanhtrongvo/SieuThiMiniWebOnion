using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
