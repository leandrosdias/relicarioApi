using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class CreateArtistaIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Artistas",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_Nome",
                table: "Artistas",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Artistas_Nome",
                table: "Artistas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Artistas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);
        }
    }
}
