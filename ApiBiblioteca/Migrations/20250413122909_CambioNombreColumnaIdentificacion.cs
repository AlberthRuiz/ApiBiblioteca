using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreColumnaIdentificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "identificacion",
                table: "Autores",
                newName: "Identificacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Autores",
                newName: "identificacion");
        }
    }
}
