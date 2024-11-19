    using Application.Features.Interface;
    using Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Application.Features.Configuration;

    namespace Persistence.Repositories
    {
        public class UserRepository : IUserService
        {
            private readonly Hshop2023Context _context;
            private readonly IPasswordHasher<User> _passwordHasher;
            private readonly SmtpSettings _smtpSettings;
            public UserRepository(Hshop2023Context context, IPasswordHasher<User> passwordHasher, IOptions<SmtpSettings> smtpSettings)
            {
                _context = context;
                _passwordHasher = passwordHasher;
                _smtpSettings = smtpSettings.Value;
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
                // Mã hóa mật khẩu trước khi lưu
                user.MatKhau = _passwordHasher.HashPassword(user, user.MatKhau);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            public async Task<User> AuthenticateUser(string email, string matKhau)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
                if (user == null)
                    return null;

                var result = _passwordHasher.VerifyHashedPassword(user, user.MatKhau, matKhau);
                if (result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
                    return user;

                return null;
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
            public async Task UpdatePassword(User user, string newPassword)
            {
                // Băm mật khẩu mới
                user.MatKhau = _passwordHasher.HashPassword(user, newPassword);

                // Cập nhật trong cơ sở dữ liệu
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            public async Task<User?> GetUserByEmail(string email)
            {
                return await _context.Users
                                     .AsNoTracking() // Tùy chọn để tăng hiệu suất khi không cần theo dõi các thay đổi
                                     .SingleOrDefaultAsync(u => u.Email == email);
            }
        public async Task SendOtpToEmail(string email, string otp)
        {
            try
            {
                using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)) // Sửa lại từ Server thành Host nếu cần
                {
                    client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    client.EnableSsl = _smtpSettings.EnableSsl;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                        Subject = "Your OTP Code",
                        Body = $"Your OTP code is: {otp}",
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(email);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                throw new InvalidOperationException("Gửi OTP không thành công", ex);
            }
        }

    }
}