using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FornecedorApi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    IDENDERECO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LOGRADOURO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.IDENDERECO);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                columns: table => new
                {
                    IDFORNECEDOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    IDENDERECO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoIdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.IDFORNECEDOR);
                    table.ForeignKey(
                        name: "FK_FORNECEDOR_ENDERECO_EnderecoIdEndereco",
                        column: x => x.EnderecoIdEndereco,
                        principalTable: "ENDERECO",
                        principalColumn: "IDENDERECO");
                    table.ForeignKey(
                        name: "FK_FORNECEDOR_ENDERECO_IDENDERECO",
                        column: x => x.IDENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "IDENDERECO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDOR_EnderecoIdEndereco",
                table: "FORNECEDOR",
                column: "EnderecoIdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDOR_IDENDERECO",
                table: "FORNECEDOR",
                column: "IDENDERECO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FORNECEDOR");

            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
