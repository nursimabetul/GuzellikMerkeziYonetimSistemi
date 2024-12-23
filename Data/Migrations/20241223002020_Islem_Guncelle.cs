using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuzellikMerkeziYonetimSistemi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Islem_Guncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems");

            migrationBuilder.AlterColumn<int>(
                name: "IslemKategoriId",
                table: "Islems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems",
                column: "IslemKategoriId",
                principalTable: "IslemKategoris",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems");

            migrationBuilder.AlterColumn<int>(
                name: "IslemKategoriId",
                table: "Islems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Islems_IslemKategoris_IslemKategoriId",
                table: "Islems",
                column: "IslemKategoriId",
                principalTable: "IslemKategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
