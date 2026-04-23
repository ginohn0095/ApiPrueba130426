using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPrueba130426.Migrations
{
    /// <inheritdoc />
    public partial class sisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabla1s",
                table: "Tabla1s");

            migrationBuilder.RenameTable(
                name: "Tabla1s",
                newName: "Tabla1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabla1",
                table: "Tabla1",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tabla1",
                table: "Tabla1");

            migrationBuilder.RenameTable(
                name: "Tabla1",
                newName: "Tabla1s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tabla1s",
                table: "Tabla1s",
                column: "Id");
        }
    }
}
