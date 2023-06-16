using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADMControl.Dominio.Migrations
{
    /// <inheritdoc />
    public partial class TabelasEntrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTRADA",
                columns: table => new
                {
                    ENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ENT_NUMERO = table.Column<int>(type: "int", nullable: false),
                    ENT_FORNECEDOR = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENT_DATA = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTRADA", x => x.ENT_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUTOXENTRADA",
                columns: table => new
                {
                    PXE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PXE_QUANTIDADE = table.Column<double>(type: "double", nullable: false),
                    PXE_IDPRODUTO = table.Column<int>(type: "int", nullable: false),
                    PXE_IDENTRADA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOXENTRADA", x => x.PXE_ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOXENTRADA_ENTRADA_PXE_IDENTRADA",
                        column: x => x.PXE_IDENTRADA,
                        principalTable: "ENTRADA",
                        principalColumn: "ENT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTOXENTRADA_PRODUTO_PXE_IDPRODUTO",
                        column: x => x.PXE_IDPRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "PRO_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOXENTRADA_PXE_IDENTRADA",
                table: "PRODUTOXENTRADA",
                column: "PXE_IDENTRADA");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOXENTRADA_PXE_IDPRODUTO",
                table: "PRODUTOXENTRADA",
                column: "PXE_IDPRODUTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOXENTRADA");

            migrationBuilder.DropTable(
                name: "ENTRADA");
        }
    }
}
