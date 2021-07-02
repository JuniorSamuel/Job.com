using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FK_UsuarioEnVacante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_IdVacante",
                table: "Solicitud");

            migrationBuilder.RenameColumn(
                name: "IdVacante",
                table: "Solicitud",
                newName: "VacanteId");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Solicitud",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitud_IdUsuario",
                table: "Solicitud",
                newName: "IX_Solicitud_UsuarioId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Fecha",
                table: "Vacante",
                type: "datetimeoffset",
                unicode: false,
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Vacante",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_IdUsuario",
                table: "Vacante",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud",
                column: "UsuarioId",
                principalTable: "Vacante",
                principalColumn: "IdVacante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Vacante__IdUsuar__70DDC3D8",
                table: "Vacante",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Vacante__IdUsuar__70DDC3D8",
                table: "Vacante");

            migrationBuilder.DropIndex(
                name: "IX_Vacante_IdUsuario",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Vacante");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Vacante");

            migrationBuilder.RenameColumn(
                name: "VacanteId",
                table: "Solicitud",
                newName: "IdVacante");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Solicitud",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Solicitud_UsuarioId",
                table: "Solicitud",
                newName: "IX_Solicitud_IdUsuario");

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

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_IdVacante",
                table: "Solicitud",
                column: "IdVacante");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud",
                column: "IdVacante",
                principalTable: "Vacante",
                principalColumn: "IdVacante",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
