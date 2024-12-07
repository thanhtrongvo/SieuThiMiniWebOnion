using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        // Lấy danh sách tất cả hóa đơn
        public async Task<IEnumerable<HoaDon>> GetAll()
        {
            return _context.HoaDons.Include(h => h.User).Include(h => h.TrangThai);
        }

        // Lấy hóa đơn theo ID
        public async Task<HoaDon> GetById(int id)
        {
            return await _context.HoaDons.FindAsync(id);
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
            _context.HoaDons.Update(hoaDon);
            await _context.SaveChangesAsync();
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
