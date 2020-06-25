using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroEstudiantes.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 255, nullable: false),
                    Codigo = table.Column<string>(maxLength: 4, nullable: false),
                    Area = table.Column<int>(nullable: false),
                    Disponible = table.Column<bool>(nullable: false),
                    Objetivos = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
