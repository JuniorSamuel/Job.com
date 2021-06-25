using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ElimnacionCascada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdUsu__403A8C7D",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Usuario__IdRol__3A81B327",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdUsu__403A8C7D",
                table: "Solicitud",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud",
                column: "IdVacante",
                principalTable: "Vacante",
                principalColumn: "IdVacante",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Usuario__IdRol__3A81B327",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdUsu__403A8C7D",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Usuario__IdRol__3A81B327",
                table: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdUsu__403A8C7D",
                table: "Solicitud",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__IdVac__412EB0B6",
                table: "Solicitud",
                column: "IdVacante",
                principalTable: "Vacante",
                principalColumn: "IdVacante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Usuario__IdRol__3A81B327",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
