using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
