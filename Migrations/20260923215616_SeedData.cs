using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaVeterinaria.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especies",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Canino" },
                    { 2, "Felino" }
                });

            migrationBuilder.InsertData(
                table: "Razas",
                columns: new[] { "Id", "IdEspecie", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Labrador" },
                    { 2, 1, "Pastor Alemán" },
                    { 3, 2, "Siamés" },
                    { 4, 2, "Persa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Razas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
