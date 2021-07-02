using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class TelefonoVacante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Telefono",
                table: "Vacante",
                type: "numeric(15,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(15,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Telefono",
                table: "Vacante",
                type: "numeric(15,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(15,0)",
                oldNullable: true);
        }
    }
}
