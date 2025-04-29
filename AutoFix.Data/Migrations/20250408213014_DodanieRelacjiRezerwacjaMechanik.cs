using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodanieRelacjiRezerwacjaMechanik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMechanika",
                table: "Rezerwacje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdMechanika",
                table: "Rezerwacje",
                column: "IdMechanika");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje",
                column: "IdMechanika",
                principalTable: "Mechanicy",
                principalColumn: "IdMechanika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Mechanicy_IdMechanika",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_IdMechanika",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "IdMechanika",
                table: "Rezerwacje");
        }
    }
}
