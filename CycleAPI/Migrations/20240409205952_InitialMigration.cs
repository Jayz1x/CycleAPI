using Microsoft.EntityFrameworkCore.Migrations;

namespace CycleAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear el esquema "CATEGORIAS"
            migrationBuilder.EnsureSchema("CATEGORIAS");

            // Crear la tabla "Products" dentro del esquema "CATEGORIAS"
            migrationBuilder.CreateTable(
                name: "CATEGORIAS.Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true)
                },
                schema: "CATEGORIAS", // Especifica el esquema aquí
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CATEGORIAS.Products",
                schema: "CATEGORIAS"); // También especifica el esquema en el método Down
        }
    }
}
