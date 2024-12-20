using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebMiniShop.Areas.Client.Helper;
using WebMiniShop.Models;

namespace WebMiniShop.Areas.Admin.Controllers;

[Area("Client")]
public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly Hshop2023Context _context;

    public AccountController(
        IUserService userService,
        IPasswordHasher<User> passwordHasher,
        Hshop2023Context context
    )
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
        _context = context;
    }

    // Hiển thị trang đăng ký
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // Xử lý đăng ký
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        [Bind("HoTen,Email,MatKhau,DienThoai,VaiTro,GioiTinh,NgaySinh,DiaChi")] User user,
        string ConfirmMatKhau
    )
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userService.GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email đã được sử dụng.");
                return View(user);
            }

            if (user.MatKhau != ConfirmMatKhau)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu không khớp.");
                return View(user);
            }

            await _userService.Add(user);
            return RedirectToAction("Login");
        }

        return View(user);
    }

    // Hiển thị trang đăng nhập
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.AuthenticateUser(model.Email, model.MatKhau);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.Email),
                    new(ClaimTypes.NameIdentifier, user.MaUser.ToString()),
                    new("CustomerId", user.MaUser.ToString()),
                    new(ClaimTypes.Role, user.VaiTro == 1 ? "Admin" : "User"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                // Điều hướng dựa trên vai trò của người dùng
                if (user.VaiTro == 1) // Admin
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                else // Khách hàng
                    return RedirectToAction("Index", "Home", new { area = "Client" });
            }

            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
        }

        return View(model);
    }

    // Xử lý đăng xuất
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    // Hiển thị trang yêu cầu OTP
    [HttpGet]
    public IActionResult RequestOtp()
    {
        return View();
    }

    // Gửi OTP qua email
    // Gửi OTP qua email
    // Gửi OTP qua email
    // Gửi OTP qua email
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendOtp(string email)
    {
        var user = await _userService.GetUserByEmail(email);
        if (user == null)
        {
            ViewBag.Message = "Không tìm thấy email.";
            return View("RequestOtp");
        }

        string otp = GenerateOtp();

        // Lưu thông tin OTP và email vào session
        HttpContext.Session.SetString("OTP", otp);
        HttpContext.Session.SetString("OTPEmail", email);
        HttpContext.Session.SetString("OtpExpiry", DateTime.Now.AddMinutes(10).ToString());

        // Lưu email vào TempData để sử dụng trong bước ResetPasswordForm
        TempData["Email"] = email;

        await _userService.SendOtpToEmail(email, otp);
        return RedirectToAction("VerifyOtpForm");
    }

    // Hiển thị trang xác nhận OTP
    [HttpGet]
    public IActionResult VerifyOtpForm()
    {
        ViewBag.Email = TempData["Email"];
        return View();
    }

    // Xử lý xác nhận OTP
    // Hiển thị trang xác nhận OTP
    // Xác minh OTP
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VerifyOtp(string email, string otp)
    {
        var sessionOtp = HttpContext.Session.GetString("OTP");
        var sessionEmail = HttpContext.Session.GetString("OTPEmail");
        var otpExpiry = HttpContext.Session.GetString("OtpExpiry");

        // Kiểm tra nếu không có thông tin OTP hoặc email trong session
        if (
            string.IsNullOrEmpty(sessionEmail)
            || string.IsNullOrEmpty(sessionOtp)
            || string.IsNullOrEmpty(otpExpiry)
        )
        {
            ViewBag.Message = "Có lỗi xảy ra, vui lòng thử lại.";
            return View("VerifyOtpForm");
        }

        // Kiểm tra nếu email và OTP không khớp
        if (sessionEmail != email || sessionOtp != otp)
        {
            ViewBag.Message = "OTP hoặc email không chính xác.";
            return View("VerifyOtpForm");
        }

        // Kiểm tra thời gian hết hạn của OTP
        if (DateTime.TryParse(otpExpiry, out var expiryTime))
        {
            if (expiryTime < DateTime.Now)
            {
                ViewBag.Message = "OTP đã hết hạn.";
                return View("VerifyOtpForm");
            }
        }

        // Nếu OTP hợp lệ và chưa hết hạn, chuyển sang trang ResetPassword
        HttpContext.Session.Remove("OTP");
        HttpContext.Session.Remove("OTPEmail");
        HttpContext.Session.Remove("OtpExpiry");

        TempData["Email"] = email; // Lưu email để truyền cho ResetPassword
        return RedirectToAction("ResetPasswordForm");
    }

    // Hiển thị form đặt lại mật khẩu
    // Hiển thị trang đặt lại mật khẩu
    [HttpGet]
    public IActionResult ResetPasswordForm()
    {
        var email = TempData["Email"]?.ToString();
        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("RequestOtp");
        }

        ViewBag.Email = email;
        return View();
    }

    // Xử lý đặt lại mật khẩu
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(
        string email,
        string newPassword,
        string confirmPassword
    )
    {
        if (newPassword != confirmPassword)
        {
            TempData["Error"] = "Mật khẩu xác nhận không khớp.";
            return RedirectToAction("ResetPasswordForm");
        }

        // Lấy người dùng từ cơ sở dữ liệu
        var user = await _userService.GetUserByEmail(email);
        if (user == null)
        {
            TempData["Error"] = "Không tìm thấy người dùng với email này.";
            return RedirectToAction("ResetPasswordForm");
        }

        // Mã hóa mật khẩu mới và lưu vào cơ sở dữ liệu
        user.MatKhau = _passwordHasher.HashPassword(user, newPassword);

        // Cập nhật thông tin người dùng trong cơ sở dữ liệu
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        TempData["Message"] = "Mật khẩu đã được thay đổi thành công.";
        return RedirectToAction("Login");
    }

    private string GenerateOtp()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    [HttpGet]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleResponse"),
        };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        var claims = result
            .Principal.Identities.FirstOrDefault()
            ?.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value,
            });

        var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        if (email != null)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    HoTen = name,
                    VaiTro = 2, // Default role for new users
                    MatKhau = _passwordHasher.HashPassword(null, Guid.NewGuid().ToString()), // Generate a random password
                };
                await _userService.Add(user);
            }

            var userClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.NameIdentifier, user.MaUser.ToString()),
                new(Setting.CLAIM_CUSTOMERID, user.MaUser.ToString()),
                new(ClaimTypes.Role, user.VaiTro == 1 ? "Admin" : "User"),
            };
            var claimsIdentity = new ClaimsIdentity(
                userClaims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            // Điều hướng dựa trên vai trò của người dùng
            if (user.VaiTro == 1) // Admin
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            else // Khách hàng
                return RedirectToAction("Index", "Home", new { area = "Client" });
        }

        return RedirectToAction("Login");
    }

    public async Task<ActionResult> Info()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            return BadRequest("Invalid user ID.");
        }

        var user = await _userService.GetById(userId);

        if (user == null)
        {
            return NotFound();
        }

        var userInfoVM = new UserInfoVM
        {
            Email = user.Email,
            PhoneNumber = user.DienThoai, // Assuming PhoneNumber is the correct property
            Address = user.DiaChi, // Assuming Address is the correct property
            FullName = user.HoTen, // Assuming FullName is the correct property
            Password = user.MatKhau, // Assuming PasswordHash is the correct property
        };

        return View(userInfoVM);
    }

    [HttpGet]
    public async Task<IActionResult> EditInfo()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            return BadRequest("Invalid user ID.");
        }

        var user = await _userService.GetById(userId);

        if (user == null)
        {
            return NotFound();
        }

        var userInfoVM = new UserInfoVM
        {
            Email = user.Email,
            PhoneNumber = user.DienThoai,
            Address = user.DiaChi,
            FullName = user.HoTen,
        };

        return View(userInfoVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditInfo(UserInfoVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.NewPassword != model.ConfirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Passwords do not match.");
            return View(model);
        }

        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            return BadRequest("Invalid user ID.");
        }

        var user = await _userService.GetById(userId);

        if (user == null)
        {
            return NotFound();
        }

        user.HoTen = model.FullName;
        user.Email = model.Email;
        user.DienThoai = model.PhoneNumber;
        user.DiaChi = model.Address;

        if (model.Password != user.MatKhau)
        {
            user.MatKhau = _passwordHasher.HashPassword(user, model.NewPassword);
        }

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Info");
    }

    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out int userId))
        {
            return BadRequest("Invalid user ID.");
        }

        var orders = await _context
            .HoaDons.Where(h => h.MaUser == userId)
            .Include(h => h.TrangThai)
            .ToListAsync();

        return View(orders);
    }
}
