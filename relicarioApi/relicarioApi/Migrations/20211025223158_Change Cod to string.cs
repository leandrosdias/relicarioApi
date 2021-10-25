using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class ChangeCodtostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "LOJA_PRODUTO",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "LOJA_CATEGORIA",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "GALERIA_PRODUTO",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "GALERIA_CATEGORIA",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "LOJA_PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "LOJA_CATEGORIA",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "GALERIA_PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "GALERIA_CATEGORIA",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);
        }
    }
}
