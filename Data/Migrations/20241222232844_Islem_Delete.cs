﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuzellikMerkeziYonetimSistemi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Islem_Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Islems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Islems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemKategoriId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IslemAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Islems_IslemKategoris_IslemKategoriId",
                        column: x => x.IslemKategoriId,
                        principalTable: "IslemKategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Islems_IslemKategoriId",
                table: "Islems",
                column: "IslemKategoriId");
        }
    }
}