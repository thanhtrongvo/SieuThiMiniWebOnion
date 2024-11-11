using Application.Features.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext
builder.Services.AddDbContext<Hshop2023Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Cấu hình dịch vụ xác thực
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Đường dẫn đến trang đăng nhập
        options.LogoutPath = "/Account/Logout";
    });

// Add services to the container.
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
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
