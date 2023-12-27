using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class EliminaTablaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_IdBarrio",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Estado_IdEstado",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdBarrio",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdEstado",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdPatente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdBarrio",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBarrio",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdBarrio",
                table: "Pedido",
                column: "IdBarrio");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEstado",
                table: "Pedido",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdPatente",
                table: "Pedido",
                column: "IdPatente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_IdBarrio",
                table: "Pedido",
                column: "IdBarrio",
                principalTable: "Barrio",
                principalColumn: "IdBarrio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Estado_IdEstado",
                table: "Pedido",
                column: "IdEstado",
                principalTable: "Estado",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido",
                column: "IdPatente",
                principalTable: "Vehiculo",
                principalColumn: "IdPatente");
        }
    }
}
