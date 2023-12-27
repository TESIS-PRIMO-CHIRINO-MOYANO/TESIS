using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class PEDIDOaceptanull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "IdPatente",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido",
                column: "IdPatente",
                principalTable: "Vehiculo",
                principalColumn: "IdPatente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "IdPatente",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Vehiculo_IdPatente",
                table: "Pedido",
                column: "IdPatente",
                principalTable: "Vehiculo",
                principalColumn: "IdPatente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
