using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodaniePromocjiIUslug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje");

            migrationBuilder.CreateTable(
                name: "Promocje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ikona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ikona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje",
                column: "IdMechanika",
                principalTable: "Mechanicy",
                principalColumn: "IdMechanika",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Promocje");

            migrationBuilder.DropTable(
                name: "Uslugi");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje",
                column: "IdMechanika",
                principalTable: "Mechanicy",
                principalColumn: "IdMechanika");
        }
    }
}
