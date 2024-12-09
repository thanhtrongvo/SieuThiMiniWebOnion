using FoodShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.ViewComponents
{
    public class PaginateViewComponent : ViewComponent
    {
        private readonly Hshop2023Context _context;

        public PaginateViewComponent(Hshop2023Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 10)
        {
            var hanghoas = _context.HangHoas.Include(h => h.Loai).OrderBy(h => h.TenHH);
            var totalItems = await hanghoas.CountAsync();
            var items = await hanghoas.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new PaginatedList<HangHoaVM>(
                items.Select(p => new HangHoaVM
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
                }).ToList(),
                totalItems,
                page,
                pageSize
            );

            return View(result);
        }
    }
}