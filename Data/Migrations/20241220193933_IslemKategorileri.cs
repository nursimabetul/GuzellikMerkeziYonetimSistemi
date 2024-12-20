using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuzellikMerkeziYonetimSistemi.Data.Migrations
{
    /// <inheritdoc />
    public partial class IslemKategorileri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Islem",
                table: "Islem");

            migrationBuilder.RenameTable(
                name: "Islem",
                newName: "Islems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Islems",
                table: "Islems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IslemKategoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemKategoris", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IslemKategoris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Islems",
                table: "Islems");

            migrationBuilder.RenameTable(
                name: "Islems",
                newName: "Islem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Islem",
                table: "Islem",
                column: "Id");
        }
    }
}
