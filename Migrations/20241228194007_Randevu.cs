using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuzellikMerkeziYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class Randevu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sils");

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GSM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Randevus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    IslemId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    durum = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevus_Islems_IslemId",
                        column: x => x.IslemId,
                        principalTable: "Islems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevus_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevus_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_IslemId",
                table: "Randevus",
                column: "IslemId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_KullaniciId",
                table: "Randevus",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_SalonId",
                table: "Randevus",
                column: "SalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevus");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.CreateTable(
                name: "Sils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sils", x => x.Id);
                });
        }
    }
}
