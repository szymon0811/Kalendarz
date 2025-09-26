using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kalendarz.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kierowcy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierowcy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zestawienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKierowcy = table.Column<int>(type: "int", nullable: false),
                    KierowcaId = table.Column<int>(type: "int", nullable: false),
                    IdToru = table.Column<int>(type: "int", nullable: false),
                    TorId = table.Column<int>(type: "int", nullable: false),
                    Czas = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zestawienia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zestawienia_Kierowcy_KierowcaId",
                        column: x => x.KierowcaId,
                        principalTable: "Kierowcy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zestawienia_Tory_TorId",
                        column: x => x.TorId,
                        principalTable: "Tory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kierowcy",
                columns: new[] { "Id", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Valterri", "Botas" },
                    { 2, "Esteban", "Okon" },
                    { 3, "Sebastian", "Vetel" },
                    { 4, "Robert", "Kubica" }
                });

            migrationBuilder.InsertData(
                table: "Tory",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Moroco Grand Prix" },
                    { 2, "Paris Grand Prix" },
                    { 3, "Sydney Grand Prix" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zestawienia_KierowcaId",
                table: "Zestawienia",
                column: "KierowcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zestawienia_TorId",
                table: "Zestawienia",
                column: "TorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zestawienia");

            migrationBuilder.DropTable(
                name: "Kierowcy");

            migrationBuilder.DropTable(
                name: "Tory");
        }
    }
}
