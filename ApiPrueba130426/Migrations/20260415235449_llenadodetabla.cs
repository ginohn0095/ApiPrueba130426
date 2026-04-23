using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiPrueba130426.Migrations
{
    /// <inheritdoc />
    public partial class llenadodetabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tabla1s",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Primero" },
                    { 2, "Segundo" },
                    { 3, "Tercero" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tabla1s",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tabla1s",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tabla1s",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
