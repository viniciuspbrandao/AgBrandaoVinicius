using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgBrandaoVinicius.Migrations
{
    public partial class show : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classedestinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classedestinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "classepromo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desconto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classepromo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classedestinos");

            migrationBuilder.DropTable(
                name: "classepromo");
        }
    }
}
