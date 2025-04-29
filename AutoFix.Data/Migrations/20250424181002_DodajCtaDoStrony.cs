using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodajCtaDoStrony : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CtaLink",
                table: "Strony",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CtaOpis",
                table: "Strony",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CtaPrzycisk",
                table: "Strony",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CtaTytul",
                table: "Strony",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ikona",
                table: "Strony",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Podtytul",
                table: "Strony",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CtaLink",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "CtaOpis",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "CtaPrzycisk",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "CtaTytul",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "Ikona",
                table: "Strony");

            migrationBuilder.DropColumn(
                name: "Podtytul",
                table: "Strony");
        }
    }
}
