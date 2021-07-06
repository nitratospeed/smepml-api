using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Diagnostico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(nullable: false),
                    Condiciones = table.Column<string>(nullable: false),
                    Preguntas = table.Column<string>(nullable: false),
                    Sintomas = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_PacienteId",
                table: "Diagnostico",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnostico");
        }
    }
}
