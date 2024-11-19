using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebMiniShop.Areas.Client.ViewComponents;

public class LoaiViewComponent : ViewComponent
{
     private readonly Hshop2023Context db;
     public LoaiViewComponent(Hshop2023Context context) => db = context;
     
     public IViewComponentResult Invoke()
     {
         var data = db.Loais.Select(lo => new LoaiVM
         {
           MaLoai = lo.MaLoai,
           TenLoai = lo.TenLoai,
           SoLuong = lo.HangHoas.Count
         }).OrderBy(p => p.TenLoai);
         return View(data);
     }
}