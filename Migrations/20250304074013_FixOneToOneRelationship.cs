using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ege.Migrations
{
    /// <inheritdoc />
    public partial class FixOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Yil = table.Column<int>(type: "INTEGER", nullable: false),
                    Marka = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Fiyat = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracDetaylar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    arac_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    motorH = table.Column<int>(type: "INTEGER", nullable: false),
                    koltukSay = table.Column<int>(type: "INTEGER", nullable: false),
                    degisenParca = table.Column<string>(type: "TEXT", nullable: false),
                    tramerKaydı = table.Column<int>(type: "INTEGER", nullable: false),
                    renk = table.Column<string>(type: "TEXT", nullable: false),
                    hp = table.Column<int>(type: "INTEGER", nullable: false),
                    tork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracDetaylar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AracDetaylar_Araclar_arac_ID",
                        column: x => x.arac_ID,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: false),
                    Yas = table.Column<int>(type: "INTEGER", nullable: false),
                    AracId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracDetaylar_arac_ID",
                table: "AracDetaylar",
                column: "arac_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_AracId",
                table: "Kullanicilar",
                column: "AracId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracDetaylar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Araclar");
        }
    }
}
