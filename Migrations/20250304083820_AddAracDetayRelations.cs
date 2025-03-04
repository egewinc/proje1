using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ege.Migrations
{
    /// <inheritdoc />
    public partial class AddAracDetayRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracDetay_Araclar_arac_ID",
                table: "AracDetay");

            migrationBuilder.RenameColumn(
                name: "arac_ID",
                table: "AracDetay",
                newName: "arac_ıd");

            migrationBuilder.RenameIndex(
                name: "IX_AracDetay_arac_ID",
                table: "AracDetay",
                newName: "IX_AracDetay_arac_ıd");

            migrationBuilder.AddForeignKey(
                name: "FK_AracDetay_Araclar_arac_ıd",
                table: "AracDetay",
                column: "arac_ıd",
                principalTable: "Araclar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracDetay_Araclar_arac_ıd",
                table: "AracDetay");

            migrationBuilder.RenameColumn(
                name: "arac_ıd",
                table: "AracDetay",
                newName: "arac_ID");

            migrationBuilder.RenameIndex(
                name: "IX_AracDetay_arac_ıd",
                table: "AracDetay",
                newName: "IX_AracDetay_arac_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AracDetay_Araclar_arac_ID",
                table: "AracDetay",
                column: "arac_ID",
                principalTable: "Araclar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
