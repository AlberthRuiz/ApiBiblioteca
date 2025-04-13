using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class NuevasColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Autores",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Autores",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "identificacion",
                table: "Autores",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "identificacion",
                table: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
