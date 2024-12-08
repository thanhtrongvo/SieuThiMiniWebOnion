using System.Security.Claims;
using Domain.Entities;
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
        {
            var userId = int.Parse(HttpContext.User.Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier)
                .Value);
            var user = new User();
            if (model.SameInfo) user = db.Users.Find(userId);

            var hoadon = new HoaDon()
            {
                MaUser = userId,

                NgayDat = DateTime.Now,
                DiaChiGiao = model.DiaChi,
                PhiVanChuyen = 15000,
                MaTrangThai = 1,
                GhiChu = model.GhiChu,
                SoDienThoai = model.SoDienThoai
            };

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Add(hoadon);
                    db.SaveChanges();

                    var cthd = new List<ChiTietHD>();
                    foreach (var item in Cart)
                    {
                        cthd.Add(new ChiTietHD()
                        {
                            MaHD = hoadon.MaHD,
                            MaHH = item.MaHH,
                            SoLuong = item.SoLuong,
                            DonGia = item.DonGia,
                            GiamGia = 0
                        });
                        db.AddRange(cthd);
                        db.SaveChanges();
                    }


                    transaction.Commit();
                    HttpContext.Session.Set<List<CartItem>>(Setting.CARTKEY, new List<CartItem>());
                    return View("Success");
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        return View(Cart);
    }
}