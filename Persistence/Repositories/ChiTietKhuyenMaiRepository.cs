using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ChiTietKhuyenMaiRepository
    {
        private readonly Hshop2023Context _context;

        public ChiTietKhuyenMaiRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy tất cả chi tiết khuyến mãi
        public async Task<IEnumerable<ChiTietKhuyenMai>> GetAllChiTietKhuyenMaiAsync()
        {
            return await _context.ChiTietKhuyenMais.ToListAsync();
        }

        // Lấy chi tiết khuyến mãi theo ID
        public async Task<ChiTietKhuyenMai?> GetChiTietKhuyenMaiByIdAsync(int id)
        {
            return await _context.ChiTietKhuyenMais.FindAsync(id);
        }

        // Thêm mới chi tiết khuyến mãi
        public async Task CreateChiTietKhuyenMaiAsync(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            _context.ChiTietKhuyenMais.Add(chiTietKhuyenMai);
            await _context.SaveChangesAsync();
        }

        // Cập nhật chi tiết khuyến mãi
        public async Task UpdateChiTietKhuyenMaiAsync(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            var existingChiTiet = await _context.ChiTietKhuyenMais.FindAsync(chiTietKhuyenMai.MaKM, chiTietKhuyenMai.MaHH);
            if (existingChiTiet != null)
            {
                existingChiTiet.MaHH = chiTietKhuyenMai.MaHH;
                existingChiTiet.MaKM = chiTietKhuyenMai.MaKM;
                await _context.SaveChangesAsync();
            }
        }

        // Xóa chi tiết khuyến mãi
        public async Task DeleteChiTietKhuyenMaiAsync(int maKM, int maHH)
        {
            var chiTietKhuyenMai = await _context.ChiTietKhuyenMais.FindAsync(maKM, maHH);
            if (chiTietKhuyenMai != null)
            {
                _context.ChiTietKhuyenMais.Remove(chiTietKhuyenMai);
                await _context.SaveChangesAsync();
            }
        }
    }
}
