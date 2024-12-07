using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace FoodShop.Controllers;

[Area("Client")]
public class HangHoaController : Controller
{
    private readonly Hshop2023Context db;

    public HangHoaController(Hshop2023Context context)
    {
        db = context;
    }

    public IActionResult Index(int? loai)
    {
        var hanghoas = db.HangHoas.Include(h => h.Loai).AsQueryable();
        if (loai.HasValue) hanghoas = hanghoas.Where(p => p.MaLoai == loai);
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
            TenLoai = p.Loai.TenLoai
        }).ToList();
        return View(result);
    }

    public IActionResult Search(string? keyword)
    {
        var hanghoas = db.HangHoas.Include(h => h.Loai).AsQueryable();
        if (!string.IsNullOrEmpty(keyword)) hanghoas = hanghoas.Where(p => p.TenHH.Contains(keyword));
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
            TenLoai = p.Loai.TenLoai
        }).ToList();
        return View("Index", result);
    }

    public IActionResult Detail(int id)
    {
        var data = db.HangHoas
            .Include(p => p.Loai)
            .SingleOrDefault(p => p.MaHH == id);
        if (data == null) return NotFound();
        data.SoLanXem++;
        db.SaveChanges();
        var result = new ChiTietHangHoaVM
        {
            MaHH = data.MaHH,
            TenHH = data.TenHH,
            Hinh = data.Hinh ?? "",
            NgaySX = data.NgaySX,
            DonGia = data.DonGia ?? 0,
            MoTa = data.MoTa,
            GiamGia = data.GiamGia,
            MaLoai = data.MaLoai,
            TenLoai = data.Loai.TenLoai,
            SoLuong = 10,
            DanhGia = 5
        };
        return View(result);
    }
}