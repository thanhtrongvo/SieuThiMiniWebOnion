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

    public async Task<IActionResult> Index(
        string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber,
        int? loai)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
        ViewData["PriceAscSortParm"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";
        ViewData["DiscountSortParm"] = sortOrder == "discount" ? "discount_desc" : "discount";

        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewData["CurrentFilter"] = searchString;

        var hanghoas = from h in db.HangHoas.Include(h => h.Loai)
                       select h;

        if (loai.HasValue)
        {
            hanghoas = hanghoas.Where(h => h.MaLoai == loai.Value);
        }

        if (!String.IsNullOrEmpty(searchString))
        {
            hanghoas = hanghoas.Where(h => h.TenHH.Contains(searchString));
        }

        switch (sortOrder)
        {
            case "name_desc":
                hanghoas = hanghoas.OrderByDescending(h => h.TenHH);
                break;
            case "Date":
                hanghoas = hanghoas.OrderBy(h => h.NgaySX);
                break;
            case "date_desc":
                hanghoas = hanghoas.OrderByDescending(h => h.NgaySX);
                break;
            case "price_asc":
                hanghoas = hanghoas.OrderBy(h => h.DonGia);
                break;
            case "price_desc":
                hanghoas = hanghoas.OrderByDescending(h => h.DonGia);
                break;
            case "discount":
                hanghoas = hanghoas.OrderByDescending(h => h.GiamGia);
                break;
            default:
                hanghoas = hanghoas.OrderBy(h => h.TenHH);
                break;
        }

        int pageSize = 10;
        var paginatedList = await PaginatedList<HangHoaVM>.CreateAsync(
            hanghoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHH,
                TenHH = p.TenHH,
                Hinh = p.Hinh ?? "",
                NgaySX = p.NgaySX,
                DonGia = p.DonGia.HasValue ? p.DonGia.Value * (1 - p.GiamGia / 100) : 0,
                MoTa = p.MoTa,
                GiamGia = p.GiamGia,
                SoLanXem = p.SoLanXem,
                MaLoai = p.MaLoai,
                TenLoai = p.Loai.TenLoai,
                DonGiaChuaGiam = p.DonGia ?? 0
            }).AsNoTracking(), pageNumber ?? 1, pageSize);

        return View(paginatedList);
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