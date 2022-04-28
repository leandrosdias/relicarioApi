using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace relicarioApi.Migrations
{
    public partial class Changeparameterclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Parameters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Parameters",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Parameters");
        }
    }
}
