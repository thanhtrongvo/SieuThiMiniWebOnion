using Application.Features.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Hshop2023Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký repository cho các interface
builder.Services.AddScoped<ILoaiService, LoaiRepository>();
builder.Services.AddScoped<IHangHoaService, HangHoaRepository>();
builder.Services.AddScoped<IKhachHangService, KhachHangRepository>();
builder.Services.AddScoped<IHoaDonService, HoaDonRepository>();
builder.Services.AddScoped<IChiTietHDService, ChiTietHDRepository>();
builder.Services.AddScoped<INhaCungCapService, NhaCungCapRepository>();

builder.Services.AddScoped<IKhuyenMaiService, KhuyenMaiRepository>();  // Sửa lại chỗ trùng lặp
builder.Services.AddScoped<INhapKhoService, NhapKhoRepository>();
builder.Services.AddScoped<ITonKhoService, TonKhoRepository>();
builder.Services.AddScoped<ILichSuGiaoDichService, LichSuGiaoDichRepository>();
builder.Services.AddScoped<IPhanQuyenService, PhanQuyenRepository>();
builder.Services.AddScoped<ITrangThaiService, TrangThaiRepository>();
builder.Services.AddScoped<IUserService, UserRepository>();




// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Thêm phần này cho môi trường phát triển
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
