using Application.Features.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly Hshop2023Context _context;

        public UserRepository(Hshop2023Context context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả người dùng
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        // Lấy người dùng theo ID
        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Thêm mới người dùng
        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // Cập nhật người dùng
        public async Task Update(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.MaUser);
            if (existingUser != null)
            {
                existingUser.HoTen = user.HoTen;
                existingUser.Email = user.Email;
                existingUser.MatKhau = user.MatKhau;
                existingUser.DienThoai = user.DienThoai;

                // Chỉ cập nhật các thuộc tính cho khách hàng nếu là khách hàng
                if (user.VaiTro == 0) // Vai trò 0 là Khách hàng
                {
                    existingUser.GioiTinh = user.GioiTinh;
                    existingUser.NgaySinh = user.NgaySinh;
                    existingUser.DiaChi = user.DiaChi;

                }

                await _context.SaveChangesAsync();
            }
        }

        // Xóa người dùng theo ID
        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}