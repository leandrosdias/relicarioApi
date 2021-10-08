using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class Categoriascontraintcodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LOJA_CATEGORIA_Codigo",
                table: "LOJA_CATEGORIA",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_CATEGORIA_Codigo",
                table: "GALERIA_CATEGORIA",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LOJA_CATEGORIA_Codigo",
                table: "LOJA_CATEGORIA");

            migrationBuilder.DropIndex(
                name: "IX_GALERIA_CATEGORIA_Codigo",
                table: "GALERIA_CATEGORIA");
        }
    }
}
