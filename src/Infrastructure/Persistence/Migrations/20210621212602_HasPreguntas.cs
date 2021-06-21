using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class HasPreguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasNivel",
                table: "Sintoma");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Sintoma");

            migrationBuilder.AddColumn<bool>(
                name: "HasPreguntas",
                table: "Sintoma",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPreguntas",
                table: "Sintoma");

            migrationBuilder.AddColumn<bool>(
                name: "HasNivel",
                table: "Sintoma",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Sintoma",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
