using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuzellikMerkeziYonetimSistemi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Islemupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IslemKategoriId",
                table: "Islems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Islems_IslemKategoriId",
                table: "Islems",
                column: "IslemKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems",
                column: "IslemKategoriId",
                principalTable: "IslemKategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems");

            migrationBuilder.DropIndex(
                name: "IX_Islems_IslemKategoriId",
                table: "Islems");

            migrationBuilder.DropColumn(
                name: "IslemKategoriId",
                table: "Islems");
        }
    }
}
