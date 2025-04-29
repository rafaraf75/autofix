using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class DodanieLinkuBezposredniegoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LinkTytul",
                table: "Strony",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "LinkBezposredni",
                table: "Strony",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkBezposredni",
                table: "Strony");

            migrationBuilder.AlterColumn<string>(
                name: "LinkTytul",
                table: "Strony",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
