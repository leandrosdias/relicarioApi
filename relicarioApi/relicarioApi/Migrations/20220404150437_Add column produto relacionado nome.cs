using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class Addcolumnprodutorelacionadonome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdutoRelacionadoNome",
                table: "LOJA_PRODUTO_RELACIONADO",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoRelacionadoNome",
                table: "LOJA_PRODUTO_RELACIONADO");
        }
    }
}
