using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CheckNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_HangHoa_HangHoaMaHH",
                table: "ChiTietHD");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHD_HangHoaMaHH",
                table: "ChiTietHD");

            migrationBuilder.DropColumn(
                name: "HangHoaMaHH",
                table: "ChiTietHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_MaHH",
                table: "ChiTietHD",
                column: "MaHH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_HangHoa_MaHH",
                table: "ChiTietHD",
                column: "MaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHD_HangHoa_MaHH",
                table: "ChiTietHD");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHD_MaHH",
                table: "ChiTietHD");

            migrationBuilder.AddColumn<int>(
                name: "HangHoaMaHH",
                table: "ChiTietHD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHD_HangHoaMaHH",
                table: "ChiTietHD",
                column: "HangHoaMaHH");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHD_HangHoa_HangHoaMaHH",
                table: "ChiTietHD",
                column: "HangHoaMaHH",
                principalTable: "HangHoa",
                principalColumn: "MaHH",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
