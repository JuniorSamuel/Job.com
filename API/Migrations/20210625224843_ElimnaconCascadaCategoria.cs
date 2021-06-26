using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ElimnaconCascadaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Vacante__IdCateg__3D5E1FD2",
                table: "Vacante");

            migrationBuilder.AddForeignKey(
                name: "FK__Vacante__IdCateg__3D5E1FD2",
                table: "Vacante",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Vacante__IdCateg__3D5E1FD2",
                table: "Vacante");

            migrationBuilder.AddForeignKey(
                name: "FK__Vacante__IdCateg__3D5E1FD2",
                table: "Vacante",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
