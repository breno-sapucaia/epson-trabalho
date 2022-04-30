using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoPIMVII.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGRADOURO = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CIDADE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ESTADO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONE_TIPO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE_TIPO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    NOME = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<long>(type: "BIGINT", nullable: false),
                    ENDERECO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PESSOA_ENDERECO_ENDERECO",
                        column: x => x.ENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TELEFONE_TELEFONE_TIPO_TIPO",
                        column: x => x.TIPO,
                        principalTable: "TELEFONE_TIPO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA_TELEFONE",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA_TELEFONE", x => new { x.PessoaId, x.TelefoneId });
                    table.ForeignKey(
                        name: "FK_PESSOA_TELEFONE_PESSOA_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PESSOA_TELEFONE_TELEFONE_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "TELEFONE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_ENDERECO",
                table: "PESSOA",
                column: "ENDERECO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_TELEFONE_TelefoneId",
                table: "PESSOA_TELEFONE",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_TIPO",
                table: "TELEFONE",
                column: "TIPO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOA_TELEFONE");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "TELEFONE");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "TELEFONE_TIPO");
        }
    }
}
