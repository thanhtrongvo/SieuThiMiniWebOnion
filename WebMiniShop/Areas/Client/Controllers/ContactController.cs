using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
