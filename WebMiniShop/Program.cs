﻿using Application.Features.Configuration;
using Application.Features.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using WebMiniShop.Areas.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext
builder.Services.AddDbContext<Hshop2023Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Đăng ký repository cho các interface
builder.Services.AddScoped<ILoaiService, LoaiRepository>();
builder.Services.AddScoped<IHangHoaService, HangHoaRepository>();
builder.Services.AddScoped<IKhachHangService, KhachHangRepository>();
builder.Services.AddScoped<IHoaDonService, HoaDonRepository>();
builder.Services.AddScoped<IChiTietHDService, ChiTietHDRepository>();
builder.Services.AddScoped<INhaCungCapService, NhaCungCapRepository>();
builder.Services.AddScoped<IKhuyenMaiService, KhuyenMaiRepository>();
builder.Services.AddScoped<INhapKhoService, NhapKhoRepository>();
builder.Services.AddScoped<ITonKhoService, TonKhoRepository>();
builder.Services.AddScoped<ILichSuGiaoDichService, LichSuGiaoDichRepository>();
builder.Services.AddScoped<IPhanQuyenService, PhanQuyenRepository>();
builder.Services.AddScoped<ITrangThaiService, TrangThaiRepository>();
builder.Services.AddScoped<IUserService, UserRepository>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Đăng ký PasswordHasher cho User entity
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Cấu hình dịch vụ xác thực
builder
    .Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Client/Account/Login";
        options.LogoutPath = "/Client/Account/Logout";
    })
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection = builder.Configuration.GetSection(
            "Authentication:Google"
        );

        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];
        options.CallbackPath = "/signin-google";
    });

builder.Services.AddSingleton<IVnPayService, VnPayService>();

// Cấu hình Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Thời gian hết hạn của Session (10 phút)
    options.Cookie.HttpOnly = true; // Bảo mật cookie của Session
    options.Cookie.IsEssential = true; // Đảm bảo Session được sử dụng ngay cả khi không có sự đồng ý của người dùng (GDPR)
});

// Thêm các dịch vụ khác
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Thêm middleware xác thực
app.UseAuthorization();

app.UseSession(); // Thêm middleware cho Session

app.MapControllerRoute("default", "{area=Client}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
