using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoPIMVII.Migrations
{
    public partial class AdicionandoUniqueParaColunaCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_CPF",
                table: "PESSOA",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PESSOA_CPF",
                table: "PESSOA");
        }
    }
}
