﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public class Hshop2023Context : DbContext
{
    public Hshop2023Context(DbContextOptions<Hshop2023Context> options)
        : base(options)
    {
    }

    // Các DbSet đại diện cho các bảng trong cơ sở dữ liệu
    public DbSet<User> Users { get; set; }

    public DbSet<TrangThai> TrangThais { get; set; }
    public DbSet<Loai> Loais { get; set; }
    public DbSet<NhaCungCap> NhaCungCaps { get; set; }
    public DbSet<KhuyenMai> KhuyenMais { get; set; }

    public DbSet<KhachHang> KhachHangs { get; set; }
    public DbSet<HangHoa> HangHoas { get; set; }
    public DbSet<HoaDon> HoaDons { get; set; }
    public DbSet<ChiTietHD> ChiTietHDs { get; set; }
    public DbSet<NhapKho> NhapKhos { get; set; }
    public DbSet<TonKho> TonKhos { get; set; }
    public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
    public DbSet<PhanQuyen> PhanQuyens { get; set; }
    public DbSet<LichSuGiaoDich> LichSuGiaoDiches { get; set; }

    // Bạn có thể thêm các cấu hình khác cho DbContext tại đây nếu cần thiết.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Định nghĩa khóa chính tổng hợp cho thực thể ChiTietKhuyenMai
        modelBuilder.Entity<ChiTietKhuyenMai>()
            .HasKey(ct => new { ct.MaKM, ct.MaHH });

        modelBuilder.Entity<HangHoa>()
            .HasOne(h => h.Loai)
            .WithMany(l => l.HangHoas)
            .HasForeignKey(h => h.MaLoai);
        // Define relationship between ChiTietHD and HangHoa
        modelBuilder.Entity<ChiTietHD>()
            .HasOne(ct => ct.HangHoa) // Navigation property
            .WithMany(h => h.ChiTietHDs) // Navigation property
            .HasForeignKey(ct => ct.MaHH) // Foreign key in ChiTietHD
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete if required

        modelBuilder.Entity<ChiTietHD>()
            .HasOne(ct => ct.HoaDon) // Navigation property in ChiTietHD
            .WithMany(hd => hd.ChiTietHDs) // Navigation property in HoaDon
            .HasForeignKey(ct => ct.MaHD) // Foreign key in ChiTietHD
            .OnDelete(DeleteBehavior.Restrict); // Adjust DeleteBehavior as needed
    }
}