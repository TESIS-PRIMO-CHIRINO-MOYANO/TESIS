using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class cambioNombreFechapedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Pedido",
                newName: "FechaPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPedido",
                table: "Pedido",
                newName: "Fecha");
        }
    }
}
