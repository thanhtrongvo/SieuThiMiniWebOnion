using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Diagnostics;

namespace FoodShop.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Hshop2023Context db;

        public HomeController(ILogger<HomeController> logger,Hshop2023Context context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
{
    var loais = db.Loais.Include(l => l.HangHoas).ToList();
    var loaiVMs = loais.Select(l => new LoaiVM
    {
        MaLoai = l.MaLoai,
        TenLoai = l.TenLoai,
        HangHoas = l.HangHoas.Select(h => new HangHoaVM
        {
            MaHH = h.MaHH,
            TenHH = h.TenHH,
            Hinh = h.Hinh,
            NgaySX = h.NgaySX,
            DonGia = h.DonGia.HasValue ? h.DonGia.Value * (1 - h.GiamGia / 100) : 0,
            MoTa = h.MoTa,
            GiamGia = h.GiamGia,
            SoLanXem = h.SoLanXem,
            MaLoai = h.MaLoai,
            TenLoai = l.TenLoai
        }).ToList()
    }).ToList();

    return View(loaiVMs);
}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}