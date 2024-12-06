using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeHangHoas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_MaLoaiNavigationMaLoai",
                table: "HangHoa");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoaiNavigationMaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoaiNavigationMaLoai",
                table: "HangHoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoaiNavigationMaLoai",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoaiNavigationMaLoai",
                table: "HangHoa",
                column: "MaLoaiNavigationMaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_MaLoaiNavigationMaLoai",
                table: "HangHoa",
                column: "MaLoaiNavigationMaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
