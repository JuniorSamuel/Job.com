using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CampoFechaEnVacante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fecha",
                table: "Vacante",
                type: "datetimeoffset",
                unicode: false,
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Vacante");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
