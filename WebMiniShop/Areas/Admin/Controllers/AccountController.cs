using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMiniShop.Models;

namespace WebMiniShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> Register([Bind("HoTen,Email,MatKhau,DienThoai,VaiTro,GioiTinh,NgaySinh,DiaChi")] User user, string ConfirmMatKhau)
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
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.MaUser.ToString()),
                new Claim(ClaimTypes.Role, user.VaiTro == 1 ? "Admin" : "User")
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent = true };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Điều hướng dựa trên vai trò của người dùng
                    if (user.VaiTro == 1) // Admin
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else // Khách hàng
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }

                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
            }
            return View(model);
        }

        // Xử lý đăng xuất
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            HttpContext.Session.SetString("OTP", otp);
            HttpContext.Session.SetString("OTPEmail", email);
            HttpContext.Session.SetString("OtpExpiry", DateTime.Now.AddMinutes(10).ToString());

            await _userService.SendOtpToEmail(email, otp);
            TempData["Email"] = email;
            return RedirectToAction("VerifyOtpForm");
        }

        // Hiển thị trang xác nhận OTP
        [HttpGet]
        public IActionResult VerifyOtpForm()
        {
            ViewBag.Email = TempData["Email"];
            return View();
        }

        // Xác minh OTP
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOtp(string email, string otp)
        {
            var sessionOtp = HttpContext.Session.GetString("OTP");
            var sessionEmail = HttpContext.Session.GetString("OTPEmail");
            var otpExpiry = HttpContext.Session.GetString("OtpExpiry");

            if (sessionEmail == email && sessionOtp == otp)
            {
                if (DateTime.TryParse(otpExpiry, out DateTime expiryTime) && expiryTime >= DateTime.Now)
                {
                    HttpContext.Session.Remove("OTP");
                    HttpContext.Session.Remove("OTPEmail");
                    HttpContext.Session.Remove("OtpExpiry");
                    TempData["Email"] = email;
                    return RedirectToAction("ResetPasswordForm");
                }
                else
                {
                    ViewBag.Message = "OTP đã hết hạn.";
                    return View("VerifyOtpForm");
                }
            }

            ViewBag.Message = "OTP hoặc email không chính xác.";
            return View("VerifyOtpForm");
        }

        // Hiển thị trang đặt lại mật khẩu
        [HttpGet]
        public IActionResult ResetPasswordForm()
        {
            ViewBag.Email = TempData["Email"];
            return View();
        }

        // Đặt lại mật khẩu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string email, string newPassword)
        {
            var sessionEmail = HttpContext.Session.GetString("OTPEmail");

            if (sessionEmail != email)
            {
                ViewBag.Message = "Email không hợp lệ.";
                return View("ResetPasswordForm");
            }

            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                ViewBag.Message = "Không tìm thấy email.";
                return View("ResetPasswordForm");
            }

            await _userService.UpdatePassword(user, newPassword);

            HttpContext.Session.Remove("OTP");
            HttpContext.Session.Remove("OTPEmail");
            HttpContext.Session.Remove("OtpExpiry");

            ViewBag.Message = "Đặt lại mật khẩu thành công.";
            return RedirectToAction("Login");
        }

        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}

