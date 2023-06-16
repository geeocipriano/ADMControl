using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADMControl.Dominio.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    PRO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PRO_IDCATEGORIA = table.Column<int>(type: "int", nullable: false),
                    PRO_IDUNIDADE = table.Column<int>(type: "int", nullable: false),
                    PRO_DESC = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRO_MIN = table.Column<double>(type: "double", nullable: false),
                    PRO_MAX = table.Column<double>(type: "double", nullable: false),
                    PRO_ATU = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.PRO_ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA_PRO_IDCATEGORIA",
                        column: x => x.PRO_IDCATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "CAT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_UNIDADE_PRO_IDUNIDADE",
                        column: x => x.PRO_IDUNIDADE,
                        principalTable: "UNIDADE",
                        principalColumn: "UNI_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PRO_IDCATEGORIA",
                table: "PRODUTO",
                column: "PRO_IDCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_PRO_IDUNIDADE",
                table: "PRODUTO",
                column: "PRO_IDUNIDADE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
