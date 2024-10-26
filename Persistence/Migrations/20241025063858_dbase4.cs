using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_PhanQuyen_NhanVienMaNV",
                table: "PhanQuyen");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_NhanVienMaNV",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNV",
                table: "PhanQuyen");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNV",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "GioiTinh",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNCC",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "NhaCungCap",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "HangHoa",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "GioiTinh",
                table: "User",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienMaNV",
                table: "PhanQuyen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNCC",
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
                name: "DienThoai",
                table: "NhaCungCap",
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
                table: "NhaCungCap",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienMaNV",
                table: "HoaDon",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hinh",
                table: "HangHoa",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyen_NhanVienMaNV",
                table: "PhanQuyen",
                column: "NhanVienMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NhanVienMaNV",
                table: "HoaDon",
                column: "NhanVienMaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienMaNV",
                table: "HoaDon",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanQuyen_NhanVien_NhanVienMaNV",
                table: "PhanQuyen",
                column: "NhanVienMaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV");
        }
    }
}
