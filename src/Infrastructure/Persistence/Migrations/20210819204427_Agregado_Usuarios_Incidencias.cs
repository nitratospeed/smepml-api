using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Agregado_Usuarios_Incidencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urgencia = table.Column<string>(maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    AdjuntoUrl = table.Column<string>(maxLength: 250, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    CreadoEn = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 250, nullable: false),
                    ActualizadoEn = table.Column<DateTime>(nullable: true),
                    ActualizadoPor = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(maxLength: 250, nullable: false),
                    Contrasena = table.Column<string>(maxLength: 250, nullable: false),
                    NombreCompleto = table.Column<string>(maxLength: 250, nullable: false),
                    Perfil = table.Column<string>(nullable: false),
                    CreadoEn = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 250, nullable: false),
                    ActualizadoEn = table.Column<DateTime>(nullable: true),
                    ActualizadoPor = table.Column<string>(maxLength: 250, nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
