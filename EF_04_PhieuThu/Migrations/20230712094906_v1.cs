using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_04_PhieuThu.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuThu_PhieuThuId",
                table: "ChiTietPhieuThu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThu_PhieuThuId",
                table: "ChiTietPhieuThu",
                column: "PhieuThuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTietPhieuThu_PhieuThuId",
                table: "ChiTietPhieuThu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuThu_PhieuThuId",
                table: "ChiTietPhieuThu",
                column: "PhieuThuId",
                unique: true);
        }
    }
}
