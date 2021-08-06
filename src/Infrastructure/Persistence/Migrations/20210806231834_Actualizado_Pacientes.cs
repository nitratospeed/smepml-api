using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Actualizado_Pacientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombresApellidos",
                table: "Paciente");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Paciente",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Paciente",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Paciente",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Paciente",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "Paciente",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Paciente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Paciente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Paciente",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Paciente");

            migrationBuilder.AddColumn<string>(
                name: "NombresApellidos",
                table: "Paciente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
