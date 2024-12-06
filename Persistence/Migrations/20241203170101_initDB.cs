using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_LoaiMaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "LoaiMaLoai",
                table: "HangHoa");

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiNavigationMaLoai",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoaiNavigationMaLoai",
                table: "HangHoa",
                column: "MaLoaiNavigationMaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa",
                column: "MaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_MaLoaiNavigationMaLoai",
                table: "HangHoa",
                column: "MaLoaiNavigationMaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_MaLoaiNavigationMaLoai",
                table: "HangHoa");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoaiNavigationMaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoaiNavigationMaLoai",
                table: "HangHoa");

            migrationBuilder.AddColumn<int>(
                name: "LoaiMaLoai",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_LoaiMaLoai",
                table: "HangHoa",
                column: "LoaiMaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_LoaiMaLoai",
                table: "HangHoa",
                column: "LoaiMaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai");
        }
    }
}
