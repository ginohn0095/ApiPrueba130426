using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiPrueba130426.Migrations
{
    /// <inheritdoc />
    public partial class olasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tabla2",
                columns: new[] { "id", "Apellido", "NumeroT" },
                values: new object[,]
                {
                    { 1, "Apellido1", 100 },
                    { 2, "Apellido2", 200 },
                    { 3, "Apellido3", 300 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tabla2",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tabla2",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tabla2",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
