﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(Hshop2023Context))]
    partial class Hshop2023ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ChiTietHD", b =>
                {
                    b.Property<int>("MaCT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCT"));

                    b.Property<float>("DonGia")
                        .HasColumnType("real");

                    b.Property<float?>("GiamGia")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int?>("MaHH")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaCT");

                    b.HasIndex("MaHD");

                    b.HasIndex("MaHH");

                    b.ToTable("ChiTietHD");
                });

            modelBuilder.Entity("Domain.Entities.ChiTietKhuyenMai", b =>
                {
                    b.Property<int>("MaKM")
                        .HasColumnType("int");

                    b.Property<int>("MaHH")
                        .HasColumnType("int");

                    b.Property<int?>("HangHoaMaHH")
                        .HasColumnType("int");

                    b.Property<int?>("KhuyenMaiMaKM")
                        .HasColumnType("int");

                    b.HasKey("MaKM", "MaHH");

                    b.HasIndex("HangHoaMaHH");

                    b.HasIndex("KhuyenMaiMaKM");

                    b.ToTable("ChiTietKhuyenMai");
                });

            modelBuilder.Entity("Domain.Entities.HangHoa", b =>
                {
                    b.Property<int>("MaHH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHH"));

                    b.Property<float?>("DonGia")
                        .HasColumnType("real");

                    b.Property<float>("GiamGia")
                        .HasColumnType("real");

                    b.Property<string>("Hinh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaKM")
                        .HasColumnType("int");

                    b.Property<int>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySX")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLanXem")
                        .HasColumnType("int");

                    b.Property<string>("TenHH")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaHH");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("Domain.Entities.HoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHD"));

                    b.Property<string>("DiaChiGiao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KhachHangMaKH")
                        .HasColumnType("int");

                    b.Property<int>("MaTrangThai")
                        .HasColumnType("int");

                    b.Property<int>("MaUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<float>("PhiVanChuyen")
                        .HasColumnType("real");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThaiMaTrangThai")
                        .HasColumnType("int");

                    b.Property<int?>("UserMaUser")
                        .HasColumnType("int");

                    b.HasKey("MaHD");

                    b.HasIndex("KhachHangMaKH");

                    b.HasIndex("TrangThaiMaTrangThai");

                    b.HasIndex("UserMaUser");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("Domain.Entities.KhachHang", b =>
                {
                    b.Property<int>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKH"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<bool>("HieuLuc")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("MaNV")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("Domain.Entities.KhuyenMai", b =>
                {
                    b.Property<int>("MaKM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKM"));

                    b.Property<string>("DieuKien")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("GiamGia")
                        .HasColumnType("real");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenChuongTrinh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaKM");

                    b.ToTable("KhuyenMai");
                });

            modelBuilder.Entity("Domain.Entities.LichSuGiaoDich", b =>
                {
                    b.Property<int>("MaGiaoDich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGiaoDich"));

                    b.Property<int?>("HoaDonMaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGiaoDich")
                        .HasColumnType("datetime2");

                    b.Property<float>("TongTien")
                        .HasColumnType("real");

                    b.Property<int?>("UserMaUser")
                        .HasColumnType("int");

                    b.HasKey("MaGiaoDich");

                    b.HasIndex("HoaDonMaHD");

                    b.HasIndex("UserMaUser");

                    b.ToTable("LichSuGiaoDich");
                });

            modelBuilder.Entity("Domain.Entities.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("Domain.Entities.NhaCungCap", b =>
                {
                    b.Property<int>("MaNCC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNCC"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNCC")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Website")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaNCC");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("Domain.Entities.NhapKho", b =>
                {
                    b.Property<int>("MaNK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNK"));

                    b.Property<float>("GiaNhap")
                        .HasColumnType("real");

                    b.Property<int?>("HangHoaMaHH")
                        .HasColumnType("int");

                    b.Property<int>("MaHH")
                        .HasColumnType("int");

                    b.Property<int>("MaNCC")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhaCungCapMaNCC")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaNK");

                    b.HasIndex("HangHoaMaHH");

                    b.HasIndex("NhaCungCapMaNCC");

                    b.ToTable("NhapKho");
                });

            modelBuilder.Entity("Domain.Entities.PhanQuyen", b =>
                {
                    b.Property<int>("MaPQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPQ"));

                    b.Property<int>("MaNV")
                        .HasColumnType("int");

                    b.Property<int>("MaTrang")
                        .HasColumnType("int");

                    b.Property<bool>("Sua")
                        .HasColumnType("bit");

                    b.Property<bool>("Them")
                        .HasColumnType("bit");

                    b.Property<int?>("UserMaUser")
                        .HasColumnType("int");

                    b.Property<bool>("Xem")
                        .HasColumnType("bit");

                    b.Property<bool>("Xoa")
                        .HasColumnType("bit");

                    b.HasKey("MaPQ");

                    b.HasIndex("UserMaUser");

                    b.ToTable("PhanQuyen");
                });

            modelBuilder.Entity("Domain.Entities.TonKho", b =>
                {
                    b.Property<int>("MaHH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHH"));

                    b.Property<int?>("HangHoaMaHH")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.HasKey("MaHH");

                    b.HasIndex("HangHoaMaHH");

                    b.ToTable("TonKho");
                });

            modelBuilder.Entity("Domain.Entities.TrangThai", b =>
                {
                    b.Property<int>("MaTrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrangThai"));

                    b.Property<string>("MoTa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaTrangThai");

                    b.ToTable("TrangThai");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("MaUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaUser"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("VaiTro")
                        .HasColumnType("int");

                    b.HasKey("MaUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.ChiTietHD", b =>
                {
                    b.HasOne("Domain.Entities.HoaDon", "HoaDon")
                        .WithMany("ChiTietHDs")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.HangHoa", "HangHoa")
                        .WithMany("ChiTietHDs")
                        .HasForeignKey("MaHH")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("HangHoa");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("Domain.Entities.ChiTietKhuyenMai", b =>
                {
                    b.HasOne("Domain.Entities.HangHoa", "HangHoa")
                        .WithMany()
                        .HasForeignKey("HangHoaMaHH");

                    b.HasOne("Domain.Entities.KhuyenMai", "KhuyenMai")
                        .WithMany("ChiTietKhuyenMais")
                        .HasForeignKey("KhuyenMaiMaKM");

                    b.Navigation("HangHoa");

                    b.Navigation("KhuyenMai");
                });

            modelBuilder.Entity("Domain.Entities.HangHoa", b =>
                {
                    b.HasOne("Domain.Entities.Loai", "Loai")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("Domain.Entities.HoaDon", b =>
                {
                    b.HasOne("Domain.Entities.KhachHang", null)
                        .WithMany("HoaDons")
                        .HasForeignKey("KhachHangMaKH");

                    b.HasOne("Domain.Entities.TrangThai", "TrangThai")
                        .WithMany("HoaDons")
                        .HasForeignKey("TrangThaiMaTrangThai");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("UserMaUser");

                    b.Navigation("TrangThai");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.LichSuGiaoDich", b =>
                {
                    b.HasOne("Domain.Entities.HoaDon", "HoaDon")
                        .WithMany()
                        .HasForeignKey("HoaDonMaHD");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserMaUser");

                    b.Navigation("HoaDon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.NhapKho", b =>
                {
                    b.HasOne("Domain.Entities.HangHoa", "HangHoa")
                        .WithMany()
                        .HasForeignKey("HangHoaMaHH");

                    b.HasOne("Domain.Entities.NhaCungCap", "NhaCungCap")
                        .WithMany("NhapKhos")
                        .HasForeignKey("NhaCungCapMaNCC");

                    b.Navigation("HangHoa");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("Domain.Entities.PhanQuyen", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("PhanQuyens")
                        .HasForeignKey("UserMaUser");
                });

            modelBuilder.Entity("Domain.Entities.TonKho", b =>
                {
                    b.HasOne("Domain.Entities.HangHoa", "HangHoa")
                        .WithMany()
                        .HasForeignKey("HangHoaMaHH");

                    b.Navigation("HangHoa");
                });

            modelBuilder.Entity("Domain.Entities.HangHoa", b =>
                {
                    b.Navigation("ChiTietHDs");
                });

            modelBuilder.Entity("Domain.Entities.HoaDon", b =>
                {
                    b.Navigation("ChiTietHDs");
                });

            modelBuilder.Entity("Domain.Entities.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Domain.Entities.KhuyenMai", b =>
                {
                    b.Navigation("ChiTietKhuyenMais");
                });

            modelBuilder.Entity("Domain.Entities.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });

            modelBuilder.Entity("Domain.Entities.NhaCungCap", b =>
                {
                    b.Navigation("NhapKhos");
                });

            modelBuilder.Entity("Domain.Entities.TrangThai", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("HoaDons");

                    b.Navigation("PhanQuyens");
                });
#pragma warning restore 612, 618
        }
    }
}
