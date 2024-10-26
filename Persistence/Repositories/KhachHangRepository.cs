using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class KhachHangRepository : IKhachHangService
    {
        private readonly Hshop2023Context _context;

        public KhachHangRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả khách hàng
        public async Task<IEnumerable<KhachHang>> GetAll()
        {
            return await _context.KhachHangs.ToListAsync();
        }

        // Lấy khách hàng theo ID
        public async Task<KhachHang?> GetById(int id)
        {
            return await _context.KhachHangs.FindAsync(id);
        }

        // Thêm mới khách hàng
        public async Task Add(KhachHang khachHang)
        {
            _context.KhachHangs.Add(khachHang);
            await _context.SaveChangesAsync();
        }

        // Cập nhật khách hàng
        public async Task Update(KhachHang khachHang)
        {
            var existingKhachHang = await _context.KhachHangs.FindAsync(khachHang.MaKH);
            if (existingKhachHang != null)
            {
                existingKhachHang.HoTen = khachHang.HoTen;
                existingKhachHang.Email = khachHang.Email;
                existingKhachHang.MatKhau = khachHang.MatKhau;
                existingKhachHang.GioiTinh = khachHang.GioiTinh;
                existingKhachHang.NgaySinh = khachHang.NgaySinh;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                existingKhachHang.DienThoai = khachHang.DienThoai;
                existingKhachHang.HieuLuc = khachHang.HieuLuc;
                existingKhachHang.VaiTro = khachHang.VaiTro;

                await _context.SaveChangesAsync();
            }
        }

        // Xóa khách hàng theo ID
        public async Task Delete(int id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHangs.Remove(khachHang);
                await _context.SaveChangesAsync();
            }
        }
    }
}
