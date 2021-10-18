using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Persistence.Migrations
{
    public partial class PacienteAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualizadoEn",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualizadoPor",
                table: "Paciente",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreadoEn",
                table: "Paciente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Paciente",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualizadoEn",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "ActualizadoPor",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "CreadoEn",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Paciente");
        }
    }
}
