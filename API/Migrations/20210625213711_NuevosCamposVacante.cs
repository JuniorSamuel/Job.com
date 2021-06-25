using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NuevosCamposVacante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Vacante",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Telefono",
                table: "Vacante",
                type: "numeric(15,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Vacante");
        }
    }
}
