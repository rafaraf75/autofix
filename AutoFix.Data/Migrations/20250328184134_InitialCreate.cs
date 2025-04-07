using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoFix.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosci",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosci", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlienta);
                });

            migrationBuilder.CreateTable(
                name: "Mechanicy",
                columns: table => new
                {
                    IdMechanika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanicy", x => x.IdMechanika);
                });

            migrationBuilder.CreateTable(
                name: "Strony",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strony", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Pojazdy",
                columns: table => new
                {
                    IdPojazdu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rok = table.Column<int>(type: "int", nullable: false),
                    NrRejestracyjny = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazdy", x => x.IdPojazdu);
                    table.ForeignKey(
                        name: "FK_Pojazdy_Klienci_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    IdRezerwacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRezerwacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usluga = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.IdRezerwacji);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Klienci_IdKlienta",
                        column: x => x.IdKlienta,
                        principalTable: "Klienci",
                        principalColumn: "IdKlienta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Naprawy",
                columns: table => new
                {
                    IdNaprawy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoZastepcze = table.Column<bool>(type: "bit", nullable: false),
                    IdPojazdu = table.Column<int>(type: "int", nullable: false),
                    IdMechanika = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naprawy", x => x.IdNaprawy);
                    table.ForeignKey(
                        name: "FK_Naprawy_Mechanicy_IdMechanika",
                        column: x => x.IdMechanika,
                        principalTable: "Mechanicy",
                        principalColumn: "IdMechanika");
                    table.ForeignKey(
                        name: "FK_Naprawy_Pojazdy_IdPojazdu",
                        column: x => x.IdPojazdu,
                        principalTable: "Pojazdy",
                        principalColumn: "IdPojazdu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutaZastepcze",
                columns: table => new
                {
                    IdAutoZastepczego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Koszt = table.Column<decimal>(type: "money", nullable: false),
                    IdNaprawy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutaZastepcze", x => x.IdAutoZastepczego);
                    table.ForeignKey(
                        name: "FK_AutaZastepcze_Naprawy_IdNaprawy",
                        column: x => x.IdNaprawy,
                        principalTable: "Naprawy",
                        principalColumn: "IdNaprawy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorieNapraw",
                columns: table => new
                {
                    IdHistorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZmiany = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpisZmiany = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IdNaprawy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorieNapraw", x => x.IdHistorii);
                    table.ForeignKey(
                        name: "FK_HistorieNapraw_Naprawy_IdNaprawy",
                        column: x => x.IdNaprawy,
                        principalTable: "Naprawy",
                        principalColumn: "IdNaprawy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutaZastepcze_IdNaprawy",
                table: "AutaZastepcze",
                column: "IdNaprawy");

            migrationBuilder.CreateIndex(
                name: "IX_HistorieNapraw_IdNaprawy",
                table: "HistorieNapraw",
                column: "IdNaprawy");

            migrationBuilder.CreateIndex(
                name: "IX_Naprawy_IdMechanika",
                table: "Naprawy",
                column: "IdMechanika");

            migrationBuilder.CreateIndex(
                name: "IX_Naprawy_IdPojazdu",
                table: "Naprawy",
                column: "IdPojazdu");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdKlienta",
                table: "Pojazdy",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_IdKlienta",
                table: "Rezerwacje",
                column: "IdKlienta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosci");

            migrationBuilder.DropTable(
                name: "AutaZastepcze");

            migrationBuilder.DropTable(
                name: "HistorieNapraw");

            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Strony");

            migrationBuilder.DropTable(
                name: "Naprawy");

            migrationBuilder.DropTable(
                name: "Mechanicy");

            migrationBuilder.DropTable(
                name: "Pojazdy");

            migrationBuilder.DropTable(
                name: "Klienci");
        }
    }
}
