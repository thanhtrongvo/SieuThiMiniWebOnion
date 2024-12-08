using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CheckNotNullChitietHD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_HoaDon_HoaDonMaHD",
                table: "ChiTietHD");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHD_HoaDonMaHD",
                table: "ChiTietHD");

            migrationBuilder.DropColumn(
                name: "HoaDonMaHD",
                table: "ChiTietHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_MaHD",
                table: "ChiTietHD",
                column: "MaHD");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_HoaDon_MaHD",
                table: "ChiTietHD",
                column: "MaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_HoaDon_MaHD",
                table: "ChiTietHD");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHD_MaHD",
                table: "ChiTietHD");

            migrationBuilder.AddColumn<int>(
                name: "HoaDonMaHD",
                table: "ChiTietHD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_HoaDonMaHD",
                table: "ChiTietHD",
                column: "HoaDonMaHD");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_HoaDon_HoaDonMaHD",
                table: "ChiTietHD",
                column: "HoaDonMaHD",
                principalTable: "HoaDon",
                principalColumn: "MaHD",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
