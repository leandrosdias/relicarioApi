using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class Changegaleriaproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GALERIA_PRODUTO_LOJA_PRODUTO_ProdutoLojaId",
                table: "GALERIA_PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_GALERIA_PRODUTO_ProdutoLojaId",
                table: "GALERIA_PRODUTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_ProdutoLojaId",
                table: "GALERIA_PRODUTO",
                column: "ProdutoLojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GALERIA_PRODUTO_LOJA_PRODUTO_ProdutoLojaId",
                table: "GALERIA_PRODUTO",
                column: "ProdutoLojaId",
                principalTable: "LOJA_PRODUTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
