using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace relicarioApi.Migrations
{
    public partial class Createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(767)", nullable: true),
                    DescricaoLonga = table.Column<string>(type: "text", nullable: true),
                    DescricaoCurta = table.Column<string>(type: "text", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GALERIA_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    CategoriaPai = table.Column<int>(type: "int", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GALERIA_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOJA_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    CodigoPai = table.Column<int>(type: "int", nullable: false),
                    BarraSuperior = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOJA_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Sobrenome = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ConfirmationCode = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOJA_PRODUTO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DescricaoCurta = table.Column<string>(type: "text", nullable: true),
                    DescricaoLonga = table.Column<string>(type: "text", nullable: true),
                    PrecoOriginal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<string>(type: "text", nullable: true),
                    Comprimento = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Largura = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CategoriaLojaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOJA_PRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOJA_PRODUTO_LOJA_CATEGORIA_CategoriaLojaId",
                        column: x => x.CategoriaLojaId,
                        principalTable: "LOJA_CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Bandeira = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_USUARIO_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    Default = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    NomeDestinatario = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIO_ENDERECO_USUARIO_UserId",
                        column: x => x.UserId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GALERIA_PRODUTO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(767)", nullable: true),
                    DescricaoCurta = table.Column<string>(type: "text", nullable: true),
                    DescricaoLonga = table.Column<string>(type: "text", nullable: true),
                    ArtistaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CategoriaGaleriaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ProdutoLojaId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GALERIA_PRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GALERIA_PRODUTO_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GALERIA_PRODUTO_GALERIA_CATEGORIA_CategoriaGaleriaId",
                        column: x => x.CategoriaGaleriaId,
                        principalTable: "GALERIA_CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GALERIA_PRODUTO_LOJA_PRODUTO_ProdutoLojaId",
                        column: x => x.ProdutoLojaId,
                        principalTable: "LOJA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOJA_PRODUTO_ATRIBUTO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<string>(type: "text", nullable: true),
                    ProdutoLojaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOJA_PRODUTO_ATRIBUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOJA_PRODUTO_ATRIBUTO_LOJA_PRODUTO_ProdutoLojaId",
                        column: x => x.ProdutoLojaId,
                        principalTable: "LOJA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOJA_PRODUTO_FOTO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    ProdutoLojaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOJA_PRODUTO_FOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOJA_PRODUTO_FOTO_LOJA_PRODUTO_ProdutoLojaId",
                        column: x => x.ProdutoLojaId,
                        principalTable: "LOJA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOJA_PRODUTO_RELACIONADO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ProdutoPrincipalId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ProdutoRelacionadoId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOJA_PRODUTO_RELACIONADO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LOJA_PRODUTO_RELACIONADO_LOJA_PRODUTO_ProdutoPrincipalId",
                        column: x => x.ProdutoPrincipalId,
                        principalTable: "LOJA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LOJA_PRODUTO_RELACIONADO_LOJA_PRODUTO_ProdutoRelacionadoId",
                        column: x => x.ProdutoRelacionadoId,
                        principalTable: "LOJA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GALERIA_PRODUTO_FOTO",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    ProdutoGategoriaId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ProdutoGaleriaId = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GALERIA_PRODUTO_FOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GALERIA_PRODUTO_FOTO_GALERIA_PRODUTO_ProdutoGaleriaId",
                        column: x => x.ProdutoGaleriaId,
                        principalTable: "GALERIA_PRODUTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_Nome",
                table: "Artistas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_CATEGORIA_Codigo",
                table: "GALERIA_CATEGORIA",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_ArtistaId",
                table: "GALERIA_PRODUTO",
                column: "ArtistaId");

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_CategoriaGaleriaId",
                table: "GALERIA_PRODUTO",
                column: "CategoriaGaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_Codigo",
                table: "GALERIA_PRODUTO",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_Nome",
                table: "GALERIA_PRODUTO",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_ProdutoLojaId",
                table: "GALERIA_PRODUTO",
                column: "ProdutoLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_GALERIA_PRODUTO_FOTO_ProdutoGaleriaId",
                table: "GALERIA_PRODUTO_FOTO",
                column: "ProdutoGaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_CATEGORIA_Codigo",
                table: "LOJA_CATEGORIA",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_PRODUTO_CategoriaLojaId",
                table: "LOJA_PRODUTO",
                column: "CategoriaLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_PRODUTO_ATRIBUTO_ProdutoLojaId",
                table: "LOJA_PRODUTO_ATRIBUTO",
                column: "ProdutoLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_PRODUTO_FOTO_ProdutoLojaId",
                table: "LOJA_PRODUTO_FOTO",
                column: "ProdutoLojaId");

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_PRODUTO_RELACIONADO_ProdutoPrincipalId",
                table: "LOJA_PRODUTO_RELACIONADO",
                column: "ProdutoPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_LOJA_PRODUTO_RELACIONADO_ProdutoRelacionadoId",
                table: "LOJA_PRODUTO_RELACIONADO",
                column: "ProdutoRelacionadoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ENDERECO_UserId",
                table: "USUARIO_ENDERECO",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "GALERIA_PRODUTO_FOTO");

            migrationBuilder.DropTable(
                name: "LOJA_PRODUTO_ATRIBUTO");

            migrationBuilder.DropTable(
                name: "LOJA_PRODUTO_FOTO");

            migrationBuilder.DropTable(
                name: "LOJA_PRODUTO_RELACIONADO");

            migrationBuilder.DropTable(
                name: "USUARIO_ENDERECO");

            migrationBuilder.DropTable(
                name: "GALERIA_PRODUTO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "GALERIA_CATEGORIA");

            migrationBuilder.DropTable(
                name: "LOJA_PRODUTO");

            migrationBuilder.DropTable(
                name: "LOJA_CATEGORIA");
        }
    }
}
