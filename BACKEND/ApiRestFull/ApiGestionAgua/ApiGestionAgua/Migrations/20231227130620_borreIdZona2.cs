using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class borreIdZona2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdBarrio",
                table: "Pedido",
                column: "IdBarrio");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_IdBarrio",
                table: "Pedido",
                column: "IdBarrio",
                principalTable: "Barrio",
                principalColumn: "IdBarrio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_IdBarrio",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdBarrio",
                table: "Pedido");
        }
    }
}
