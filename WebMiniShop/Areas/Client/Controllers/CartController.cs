using System.Security.Claims;
using FoodShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using WebMiniShop.Areas.Client.Helper;

namespace FoodShop.Controllers;

[Area("Client")]
public class CartController : Controller
{
    private readonly Hshop2023Context db;


    public CartController(Hshop2023Context context)
    {
        db = context;
    }

    public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(Setting.CARTKEY) ?? new List<CartItem>();


    public IActionResult Index()
    {
        return View(Cart);
    }

    public IActionResult AddToCart(int id, int quantity = 1)
    {
        var cartItem = Cart;
        var item = cartItem.SingleOrDefault(p => p.MaHH == id);
        if (item != null)
        {
            item.SoLuong += quantity;
        }
        else
        {
            var hangHoa = db.HangHoas.Find(id);
            if (hangHoa != null)
                cartItem.Add(new CartItem
                {
                    MaHH = hangHoa.MaHH,
                    TenHH = hangHoa.TenHH,
                    Hinh = hangHoa.Hinh ?? "",
                    DonGia = hangHoa.DonGia ?? 0,
                    SoLuong = quantity
                });
        }

        HttpContext.Session.Set(Setting.CARTKEY, cartItem);
        return RedirectToAction("Index");
    }

    public IActionResult RemoveCart(int id)
    {
        var cartItem = Cart;
        var item = cartItem.SingleOrDefault(p => p.MaHH == id);
        if (item != null) cartItem.Remove(item);
        HttpContext.Session.Set(Setting.CARTKEY, cartItem);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize]
    public IActionResult ThanhToan()
    {
        var cartItem = Cart;
        if (cartItem.Count == 0) return RedirectToAction("Index");

        return View(Cart);
    }

    [HttpPost]
    [Authorize]
    public IActionResult ThanhToan(CheckOutVM model)
    {
        if (ModelState.IsValid)
            var customerId = HttpContext.User.Claims.SingleOrDefault(c => c.Type == Setting.CUSTOMERID)?.Value;
    }
}

}