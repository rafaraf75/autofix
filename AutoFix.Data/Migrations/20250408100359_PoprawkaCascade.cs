using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class PoprawkaCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje");

            migrationBuilder.AddColumn<int>(
                name: "IdPojazdu",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Silnik",
                table: "Pojazdy",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdPojazdu",
                table: "Rezerwacje",
                column: "IdPojazdu");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje",
                column: "IdKlienta",
                principalTable: "Klienci",
                principalColumn: "IdKlienta",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Pojazdy_IdPojazdu",
                table: "Rezerwacje",
                column: "IdPojazdu",
                principalTable: "Pojazdy",
                principalColumn: "IdPojazdu",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Pojazdy_IdPojazdu",
                table: "Rezerwacje");

            migrationBuilder.DropIndex(
                name: "IX_Rezerwacje_IdPojazdu",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "IdPojazdu",
                table: "Rezerwacje");

            migrationBuilder.DropColumn(
                name: "Silnik",
                table: "Pojazdy");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Klienci_IdKlienta",
                table: "Rezerwacje",
                column: "IdKlienta",
                principalTable: "Klienci",
                principalColumn: "IdKlienta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
