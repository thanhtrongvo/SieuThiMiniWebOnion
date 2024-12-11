using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class HoaDonRepository : IHoaDonService
    {
        private readonly Hshop2023Context _context;

        public HoaDonRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả hóa đơn (Include các navigation properties)
        public async Task<IEnumerable<HoaDon>> GetAll()
        {
            return await _context.HoaDons
                .Include(h => h.User) // Bao gồm thông tin người dùng
                .Include(h => h.TrangThai) // Bao gồm trạng thái
                .Include(h => h.ChiTietHDs) // Bao gồm danh sách chi tiết hóa đơn
                    .ThenInclude(c => c.HangHoa) // Bao gồm thông tin hàng hóa trong chi tiết
                .ToListAsync();
        }

        // Lấy hóa đơn theo ID (Include các navigation properties)
        public async Task<HoaDon> GetById(int id)
        {
            return await _context.HoaDons
                .Include(h => h.User)
                .Include(h => h.TrangThai)
                .Include(h => h.ChiTietHDs)
                    .ThenInclude(c => c.HangHoa)
                .FirstOrDefaultAsync(h => h.MaHD == id);
        }

        // Tạo mới hóa đơn
        public async Task Add(HoaDon hoaDon)
        {
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();
        }

        // Cập nhật hóa đơn
        public async Task Update(HoaDon hoaDon)
        {
            var existingHoaDon = await _context.HoaDons.FindAsync(hoaDon.MaHD);
            if (existingHoaDon != null)
            {
                existingHoaDon.NgayDat = hoaDon.NgayDat;
                existingHoaDon.NgayCan = hoaDon.NgayCan;
                existingHoaDon.NgayGiao = hoaDon.NgayGiao;
                existingHoaDon.DiaChiGiao = hoaDon.DiaChiGiao;
                existingHoaDon.PhiVanChuyen = hoaDon.PhiVanChuyen;
                existingHoaDon.MaTrangThai = hoaDon.MaTrangThai;
                existingHoaDon.GhiChu = hoaDon.GhiChu;
                existingHoaDon.SoDienThoai = hoaDon.SoDienThoai;

                _context.HoaDons.Update(existingHoaDon);
                await _context.SaveChangesAsync();
            }
        }

        // Xóa hóa đơn theo ID
        public async Task Delete(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDons.Remove(hoaDon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
