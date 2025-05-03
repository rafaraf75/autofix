using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeIdNaprawyNullableInAutoZastepcze : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutaZastepcze_Naprawy_IdNaprawy",
                table: "AutaZastepcze");

            migrationBuilder.AlterColumn<int>(
                name: "IdNaprawy",
                table: "AutaZastepcze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AutaZastepcze_Naprawy_IdNaprawy",
                table: "AutaZastepcze",
                column: "IdNaprawy",
                principalTable: "Naprawy",
                principalColumn: "IdNaprawy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutaZastepcze_Naprawy_IdNaprawy",
                table: "AutaZastepcze");

            migrationBuilder.AlterColumn<int>(
                name: "IdNaprawy",
                table: "AutaZastepcze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutaZastepcze_Naprawy_IdNaprawy",
                table: "AutaZastepcze",
                column: "IdNaprawy",
                principalTable: "Naprawy",
                principalColumn: "IdNaprawy",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
