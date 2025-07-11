using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad4LengProg3.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaCalificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");
        }
    }
}
