using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbaseupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMai_HangHoa_HangHoaMaHH",
                table: "ChiTietKhuyenMai");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMai_KhuyenMai_KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai");

            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangMaKH",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_TrangThai_TrangThaiMaTrangThai",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuGiaoDich_HoaDon_HoaDonMaHD",
                table: "LichSuGiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuGiaoDich_KhachHang_KhachHangMaKH",
                table: "LichSuGiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKho_HangHoa_HangHoaMaHH",
                table: "NhapKho");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKho_NhaCungCap_NhaCungCapMaNCC",
                table: "NhapKho");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_TonKho_HangHoa_HangHoaMaHH",
                table: "TonKho");

            migrationBuilder.DropIndex(
                name: "IX_LichSuGiaoDich_KhachHangMaKH",
                table: "LichSuGiaoDich");

            migrationBuilder.DropColumn(
                name: "KhachHangMaKH",
                table: "LichSuGiaoDich");

            migrationBuilder.DropColumn(
                name: "MaKH",
                table: "HoaDon");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "LichSuGiaoDich",
                newName: "MaUser");

            migrationBuilder.RenameColumn(
                name: "MaNV",
                table: "HoaDon",
                newName: "MaUser");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "TrangThai",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "TonKho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienMaNV",
                table: "PhanQuyen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserMaUser",
                table: "PhanQuyen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapMaNCC",
                table: "NhapKho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "NhapKho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "NhanVien",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhaCungCap",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "Loai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "HoaDonMaHD",
                table: "LichSuGiaoDich",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserMaUser",
                table: "LichSuGiaoDich",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DieuKien",
                table: "KhuyenMai",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "KhachHang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "KhachHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThaiMaTrangThai",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienMaNV",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangMaKH",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserMaUser",
                table: "HoaDon",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "HangHoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LoaiMaLoai",
                table: "HangHoa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "ChiTietKhuyenMai",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    MaUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VaiTro = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.MaUser);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyen_UserMaUser",
                table: "PhanQuyen",
                column: "UserMaUser");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuGiaoDich_UserMaUser",
                table: "LichSuGiaoDich",
                column: "UserMaUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_UserMaUser",
                table: "HoaDon",
                column: "UserMaUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMai_HangHoa_HangHoaMaHH",
                table: "ChiTietKhuyenMai",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMai_KhuyenMai_KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai",
                column: "KhuyenMaiMaKM",
                principalTable: "KhuyenMai",
                principalColumn: "MaKM");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa",
                column: "LoaiMaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangMaKH",
                table: "HoaDon",
                column: "KhachHangMaKH",
                principalTable: "KhachHang",
                principalColumn: "MaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_TrangThai_TrangThaiMaTrangThai",
                table: "HoaDon",
                column: "TrangThaiMaTrangThai",
                principalTable: "TrangThai",
                principalColumn: "MaTrangThai");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_User_UserMaUser",
                table: "HoaDon",
                column: "UserMaUser",
                principalTable: "User",
                principalColumn: "MaUser");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuGiaoDich_HoaDon_HoaDonMaHD",
                table: "LichSuGiaoDich",
                column: "HoaDonMaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuGiaoDich_User_UserMaUser",
                table: "LichSuGiaoDich",
                column: "UserMaUser",
                principalTable: "User",
                principalColumn: "MaUser");

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKho_HangHoa_HangHoaMaHH",
                table: "NhapKho",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH");

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKho_NhaCungCap_NhaCungCapMaNCC",
                table: "NhapKho",
                column: "NhaCungCapMaNCC",
                principalTable: "NhaCungCap",
                principalColumn: "MaNCC");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_User_UserMaUser",
                table: "PhanQuyen",
                column: "UserMaUser",
                principalTable: "User",
                principalColumn: "MaUser");

            migrationBuilder.AddForeignKey(
                name: "FK_TonKho_HangHoa_HangHoaMaHH",
                table: "TonKho",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMai_HangHoa_HangHoaMaHH",
                table: "ChiTietKhuyenMai");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietKhuyenMai_KhuyenMai_KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai");

            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangMaKH",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_TrangThai_TrangThaiMaTrangThai",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_User_UserMaUser",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuGiaoDich_HoaDon_HoaDonMaHD",
                table: "LichSuGiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuGiaoDich_User_UserMaUser",
                table: "LichSuGiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKho_HangHoa_HangHoaMaHH",
                table: "NhapKho");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKho_NhaCungCap_NhaCungCapMaNCC",
                table: "NhapKho");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_User_UserMaUser",
                table: "PhanQuyen");

            migrationBuilder.DropForeignKey(
                name: "FK_TonKho_HangHoa_HangHoaMaHH",
                table: "TonKho");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_PhanQuyen_UserMaUser",
                table: "PhanQuyen");

            migrationBuilder.DropIndex(
                name: "IX_LichSuGiaoDich_UserMaUser",
                table: "LichSuGiaoDich");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_UserMaUser",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "UserMaUser",
                table: "PhanQuyen");

            migrationBuilder.DropColumn(
                name: "UserMaUser",
                table: "LichSuGiaoDich");

            migrationBuilder.DropColumn(
                name: "UserMaUser",
                table: "HoaDon");

            migrationBuilder.RenameColumn(
                name: "MaUser",
                table: "LichSuGiaoDich",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "MaUser",
                table: "HoaDon",
                newName: "MaNV");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "TrangThai",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "TonKho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienMaNV",
                table: "PhanQuyen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapMaNCC",
                table: "NhapKho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "NhapKho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "NhanVien",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "NhaCungCap",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "Loai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HoaDonMaHD",
                table: "LichSuGiaoDich",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KhachHangMaKH",
                table: "LichSuGiaoDich",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DieuKien",
                table: "KhuyenMai",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "KhachHang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "KhachHang",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "KhachHang",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThaiMaTrangThai",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienMaNV",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangMaKH",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaKH",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "HangHoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoaiMaLoai",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HangHoaMaHH",
                table: "ChiTietKhuyenMai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSuGiaoDich_KhachHangMaKH",
                table: "LichSuGiaoDich",
                column: "KhachHangMaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMai_HangHoa_HangHoaMaHH",
                table: "ChiTietKhuyenMai",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietKhuyenMai_KhuyenMai_KhuyenMaiMaKM",
                table: "ChiTietKhuyenMai",
                column: "KhuyenMaiMaKM",
                principalTable: "KhuyenMai",
                principalColumn: "MaKM",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa",
                column: "LoaiMaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangMaKH",
                table: "HoaDon",
                column: "KhachHangMaKH",
                principalTable: "KhachHang",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_TrangThai_TrangThaiMaTrangThai",
                table: "HoaDon",
                column: "TrangThaiMaTrangThai",
                principalTable: "TrangThai",
                principalColumn: "MaTrangThai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuGiaoDich_HoaDon_HoaDonMaHD",
                table: "LichSuGiaoDich",
                column: "HoaDonMaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuGiaoDich_KhachHang_KhachHangMaKH",
                table: "LichSuGiaoDich",
                column: "KhachHangMaKH",
                principalTable: "KhachHang",
                principalColumn: "MaKH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKho_HangHoa_HangHoaMaHH",
                table: "NhapKho",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKho_NhaCungCap_NhaCungCapMaNCC",
                table: "NhapKho",
                column: "NhaCungCapMaNCC",
                principalTable: "NhaCungCap",
                principalColumn: "MaNCC",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TonKho_HangHoa_HangHoaMaHH",
                table: "TonKho",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
