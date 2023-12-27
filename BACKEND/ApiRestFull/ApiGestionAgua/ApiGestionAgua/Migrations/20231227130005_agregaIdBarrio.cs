using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class agregaIdBarrio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBarrio",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "IdZona",
                table: "Pedido");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBarrio",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdZona",
                table: "Pedido");
        }
    }
}
