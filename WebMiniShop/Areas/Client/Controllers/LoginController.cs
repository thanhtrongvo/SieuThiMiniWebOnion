using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    public class LoginController : Controller
    {
		public IActionResult Index()
		{
            ViewBag.HideFooter = true;
            return View();
		}
	}
}
