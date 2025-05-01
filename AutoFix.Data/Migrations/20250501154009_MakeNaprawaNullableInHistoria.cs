using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeNaprawaNullableInHistoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorieNapraw_Naprawy_IdNaprawy",
                table: "HistorieNapraw");

            migrationBuilder.AlterColumn<int>(
                name: "IdNaprawy",
                table: "HistorieNapraw",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NaprawaIdNaprawy",
                table: "HistorieNapraw",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorieNapraw_NaprawaIdNaprawy",
                table: "HistorieNapraw",
                column: "NaprawaIdNaprawy");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorieNapraw_Naprawy_IdNaprawy",
                table: "HistorieNapraw",
                column: "IdNaprawy",
                principalTable: "Naprawy",
                principalColumn: "IdNaprawy",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorieNapraw_Naprawy_NaprawaIdNaprawy",
                table: "HistorieNapraw",
                column: "NaprawaIdNaprawy",
                principalTable: "Naprawy",
                principalColumn: "IdNaprawy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorieNapraw_Naprawy_IdNaprawy",
                table: "HistorieNapraw");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorieNapraw_Naprawy_NaprawaIdNaprawy",
                table: "HistorieNapraw");

            migrationBuilder.DropIndex(
                name: "IX_HistorieNapraw_NaprawaIdNaprawy",
                table: "HistorieNapraw");

            migrationBuilder.DropColumn(
                name: "NaprawaIdNaprawy",
                table: "HistorieNapraw");

            migrationBuilder.AlterColumn<int>(
                name: "IdNaprawy",
                table: "HistorieNapraw",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorieNapraw_Naprawy_IdNaprawy",
                table: "HistorieNapraw",
                column: "IdNaprawy",
                principalTable: "Naprawy",
                principalColumn: "IdNaprawy",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
