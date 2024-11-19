using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class ShopDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
