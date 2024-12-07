using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using WebMiniShop.Areas.Client.Helper;

namespace WebMiniShop.Areas.Client.ViewComponents;

public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var cart = HttpContext.Session.Get<List<CartItem>>(Setting.CARTKEY) ?? new List<CartItem>();


        return View("_CartPannel", new CartModel
        {
            Quantity = cart.Sum(p => p.SoLuong),
            Total = cart.Sum(p => p.SoLuong * p.DonGia)
        });
    }
}