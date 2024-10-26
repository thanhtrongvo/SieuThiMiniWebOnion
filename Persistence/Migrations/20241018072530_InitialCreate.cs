using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HieuLuc = table.Column<bool>(type: "bit", nullable: false),
                    VaiTro = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuongTrinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamGia = table.Column<float>(type: "real", nullable: false),
                    DieuKien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNCC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "TrangThai",
                columns: table => new
                {
                    MaTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThai", x => x.MaTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    LoaiMaLoai = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<float>(type: "real", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgaySX = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamGia = table.Column<float>(type: "real", nullable: false),
                    SoLanXem = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHH);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_LoaiMaLoai",
                        column: x => x.LoaiMaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    MaPQ = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    NhanVienMaNV = table.Column<int>(type: "int", nullable: false),
                    MaTrang = table.Column<int>(type: "int", nullable: false),
                    Them = table.Column<bool>(type: "bit", nullable: false),
                    Sua = table.Column<bool>(type: "bit", nullable: false),
                    Xoa = table.Column<bool>(type: "bit", nullable: false),
                    Xem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.MaPQ);
                    table.ForeignKey(
                        name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                        column: x => x.NhanVienMaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    KhachHangMaKH = table.Column<int>(type: "int", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    NhanVienMaNV = table.Column<int>(type: "int", nullable: false),
                    PhiVanChuyen = table.Column<float>(type: "real", nullable: false),
                    MaTrangThai = table.Column<int>(type: "int", nullable: false),
                    TrangThaiMaTrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                        column: x => x.NhanVienMaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_TrangThai_TrangThaiMaTrangThai",
                        column: x => x.TrangThaiMaTrangThai,
                        principalTable: "TrangThai",
                        principalColumn: "MaTrangThai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhuyenMai",
                columns: table => new
                {
                    MaKM = table.Column<int>(type: "int", nullable: false),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    KhuyenMaiMaKM = table.Column<int>(type: "int", nullable: false),
                    HangHoaMaHH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhuyenMai", x => new { x.MaKM, x.MaHH });
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_HangHoa_HangHoaMaHH",
                        column: x => x.HangHoaMaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_KhuyenMai_KhuyenMaiMaKM",
                        column: x => x.KhuyenMaiMaKM,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaKM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapKho",
                columns: table => new
                {
                    MaNK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNCC = table.Column<int>(type: "int", nullable: false),
                    NhaCungCapMaNCC = table.Column<int>(type: "int", nullable: false),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    HangHoaMaHH = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKho", x => x.MaNK);
                    table.ForeignKey(
                        name: "FK_NhapKho_HangHoa_HangHoaMaHH",
                        column: x => x.HangHoaMaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKho_NhaCungCap_NhaCungCapMaNCC",
                        column: x => x.NhaCungCapMaNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TonKho",
                columns: table => new
                {
                    MaHH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HangHoaMaHH = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonKho", x => x.MaHH);
                    table.ForeignKey(
                        name: "FK_TonKho_HangHoa_HangHoaMaHH",
                        column: x => x.HangHoaMaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHD",
                columns: table => new
                {
                    MaCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    HoaDonMaHD = table.Column<int>(type: "int", nullable: false),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    HangHoaMaHH = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<float>(type: "real", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiamGia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHD", x => x.MaCT);
                    table.ForeignKey(
                        name: "FK_ChiTietHD_HangHoa_HangHoaMaHH",
                        column: x => x.HangHoaMaHH,
                        principalTable: "HangHoa",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHD_HoaDon_HoaDonMaHD",
                        column: x => x.HoaDonMaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "LichSuGiaoDich",
                columns: table => new
                {
                    MaGiaoDich = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(nullable: false),
                    KhachHangMaKH = table.Column<int>(nullable: false),
                    MaHD = table.Column<int>(nullable: false),
                    HoaDonMaHD = table.Column<int>(nullable: false),
                    NgayGiaoDich = table.Column<DateTime>(nullable: false),
                    TongTien = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuGiaoDich", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_LichSuGiaoDich_HoaDon_HoaDonMaHD",
                        column: x => x.HoaDonMaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.NoAction);  // Thay đổi thành NoAction
                    table.ForeignKey(
                        name: "FK_LichSuGiaoDich_KhachHang_KhachHangMaKH",
                        column: x => x.KhachHangMaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.NoAction);  // Thay đổi thành NoAction
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_HangHoaMaHH",
                table: "ChiTietHD",
                column: "HangHoaMaHH");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_HoaDonMaHD",
                table: "ChiTietHD",
                column: "HoaDonMaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMai_HangHoaMaHH",
                table: "ChiTietKhuyenMai",
                column: "HangHoaMaHH");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMai_KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai",
                column: "KhuyenMaiMaKM");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_LoaiMaLoai",
                table: "HangHoa",
                column: "LoaiMaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_KhachHangMaKH",
                table: "HoaDon",
                column: "KhachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NhanVienMaNV",
                table: "HoaDon",
                column: "NhanVienMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_TrangThaiMaTrangThai",
                table: "HoaDon",
                column: "TrangThaiMaTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuGiaoDich_HoaDonMaHD",
                table: "LichSuGiaoDich",
                column: "HoaDonMaHD");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuGiaoDich_KhachHangMaKH",
                table: "LichSuGiaoDich",
                column: "KhachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKho_HangHoaMaHH",
                table: "NhapKho",
                column: "HangHoaMaHH");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKho_NhaCungCapMaNCC",
                table: "NhapKho",
                column: "NhaCungCapMaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyen_NhanVienMaNV",
                table: "PhanQuyen",
                column: "NhanVienMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_TonKho_HangHoaMaHH",
                table: "TonKho",
                column: "HangHoaMaHH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHD");

            migrationBuilder.DropTable(
                name: "ChiTietKhuyenMai");

            migrationBuilder.DropTable(
                name: "LichSuGiaoDich");

            migrationBuilder.DropTable(
                name: "NhapKho");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "TonKho");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TrangThai");

            migrationBuilder.DropTable(
                name: "Loai");
        }
    }
}
