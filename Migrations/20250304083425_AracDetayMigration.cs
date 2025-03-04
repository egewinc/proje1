using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ege.Migrations
{
    /// <inheritdoc />
    public partial class AracDetayMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracDetaylar_Araclar_arac_ID",
                table: "AracDetaylar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracDetaylar",
                table: "AracDetaylar");

            migrationBuilder.RenameTable(
                name: "AracDetaylar",
                newName: "AracDetay");

            migrationBuilder.RenameIndex(
                name: "IX_AracDetaylar_arac_ID",
                table: "AracDetay",
                newName: "IX_AracDetay_arac_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracDetay",
                table: "AracDetay",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AracDetay_Araclar_arac_ID",
                table: "AracDetay",
                column: "arac_ID",
                principalTable: "Araclar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracDetay_Araclar_arac_ID",
                table: "AracDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracDetay",
                table: "AracDetay");

            migrationBuilder.RenameTable(
                name: "AracDetay",
                newName: "AracDetaylar");

            migrationBuilder.RenameIndex(
                name: "IX_AracDetay_arac_ID",
                table: "AracDetaylar",
                newName: "IX_AracDetaylar_arac_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracDetaylar",
                table: "AracDetaylar",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AracDetaylar_Araclar_arac_ID",
                table: "AracDetaylar",
                column: "arac_ID",
                principalTable: "Araclar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
