using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240C67C6A53F", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__2A49584C867FA551", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Vacante",
                columns: table => new
                {
                    IdVacante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    Compania = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Posicion = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Horario = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vacante__A58A8FA8D68A2AD6", x => x.IdVacante);
                    table.ForeignKey(
                        name: "FK__Vacante__IdCateg__3D5E1FD2",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Correo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Contrasena = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Cedula = table.Column<decimal>(type: "numeric(11,0)", nullable: true),
                    Telefono = table.Column<decimal>(type: "numeric(15,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF97B0B36473", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__IdRol__3A81B327",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    VacanteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__36899CEFD05F3FF4", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK__Solicitud__IdUsu__403A8C7D",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Solicitud__IdVac__412EB0B6",
                        column: x => x.UsuarioId,
                        principalTable: "Vacante",
                        principalColumn: "IdVacante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_UsuarioId",
                table: "Solicitud",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Vacante_IdCategoria",
                table: "Vacante",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vacante");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
