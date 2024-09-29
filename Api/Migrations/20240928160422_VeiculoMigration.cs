using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api.Migrations
{
    public partial class VeiculoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_administradors",
                table: "administradors");

            migrationBuilder.RenameTable(
                name: "administradors",
                newName: "administradores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_administradores",
                table: "administradores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_administradores",
                table: "administradores");

            migrationBuilder.RenameTable(
                name: "administradores",
                newName: "administradors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_administradors",
                table: "administradors",
                column: "Id");
        }
    }
}
