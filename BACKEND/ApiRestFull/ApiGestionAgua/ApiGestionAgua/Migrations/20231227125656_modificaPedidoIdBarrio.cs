using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class modificaPedidoIdBarrio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Zona_IdZona",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdZona",
                table: "Pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdZona",
                table: "Pedido",
                column: "IdZona");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Zona_IdZona",
                table: "Pedido",
                column: "IdZona",
                principalTable: "Zona",
                principalColumn: "IdZona",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
