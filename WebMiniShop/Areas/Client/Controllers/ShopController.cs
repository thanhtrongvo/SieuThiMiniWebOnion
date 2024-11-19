using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class ShopController : Controller
    
    {
        private readonly Hshop2023Context db;
        public ShopController(Hshop2023Context context) => db = context;
        public IActionResult Index(int? loai)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hanghoas = hanghoas.Where(p => p.MaLoai == loai);
            }
            var result = hanghoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHH,
                TenHH = p.TenHH,
                Hinh = p.Hinh ?? "",
                NgaySX = p.NgaySX,
                DonGia = p.DonGia ?? 0,
                MoTa = p.MoTa,
                GiamGia = p.GiamGia,
                SoLanXem = p.SoLanXem,
                MaLoai = p.MaLoai,
                
            });
            return View();
            
        }
    }
}
