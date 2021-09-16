using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Persistence.Migrations
{
    public partial class DiagnosticoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResultadoMasPreciso",
                table: "Diagnostico",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualizadoEn",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActualizadoPor",
                table: "Diagnostico",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreadoEn",
                table: "Diagnostico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Diagnostico",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resultados",
                table: "Diagnostico",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualizadoEn",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "ActualizadoPor",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "CreadoEn",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "Resultados",
                table: "Diagnostico");

            migrationBuilder.AlterColumn<string>(
                name: "ResultadoMasPreciso",
                table: "Diagnostico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
