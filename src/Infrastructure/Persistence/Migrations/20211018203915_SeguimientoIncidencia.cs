using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class SeguimientoIncidencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    IncidenciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimiento_Incidencia_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_IncidenciaId",
                table: "Seguimiento",
                column: "IncidenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguimiento");
        }
    }
}
