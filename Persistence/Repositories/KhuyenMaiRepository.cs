using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class KhuyenMaiRepository : IKhuyenMaiService
    {
        private readonly Hshop2023Context _context;

        public KhuyenMaiRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Triển khai phương thức lấy tất cả khuyến mãi
        public async Task<IEnumerable<KhuyenMai>> GetAll()
        {
            return await _context.KhuyenMais.ToListAsync();
        }

        // Lấy chi tiết một khuyến mãi theo ID
        public async Task<KhuyenMai?> GetById(int id)
        {
            return await _context.KhuyenMais.FindAsync(id);
        }

        // Thêm mới khuyến mãi
        public async Task Add(KhuyenMai khuyenMai)
        {
            _context.KhuyenMais.Add(khuyenMai);
            await _context.SaveChangesAsync();
        }

        // Cập nhật khuyến mãi
        public async Task Update(KhuyenMai khuyenMai)
        {
            var existingKhuyenMai = await _context.KhuyenMais.FindAsync(khuyenMai.MaKM);
            if (existingKhuyenMai != null)
            {
                existingKhuyenMai.TenChuongTrinh = khuyenMai.TenChuongTrinh;
                existingKhuyenMai.NgayBatDau = khuyenMai.NgayBatDau;
                existingKhuyenMai.NgayKetThuc = khuyenMai.NgayKetThuc;
                existingKhuyenMai.GiamGia = khuyenMai.GiamGia;
                existingKhuyenMai.DieuKien = khuyenMai.DieuKien;

                await _context.SaveChangesAsync();
            }
        }

        // Xóa khuyến mãi
        public async Task Delete(int id)
        {
            var khuyenMai = await _context.KhuyenMais.FindAsync(id);
            if (khuyenMai != null)
            {
                _context.KhuyenMais.Remove(khuyenMai);
                await _context.SaveChangesAsync();
            }
        }
    }
}
