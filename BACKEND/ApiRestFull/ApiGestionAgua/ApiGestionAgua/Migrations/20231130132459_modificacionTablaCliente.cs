using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class modificacionTablaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barrio",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "IdBarrio",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdBarrio",
                table: "Cliente",
                column: "IdBarrio");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Barrio_IdBarrio",
                table: "Cliente",
                column: "IdBarrio",
                principalTable: "Barrio",
                principalColumn: "IdBarrio",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Barrio_IdBarrio",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdBarrio",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdBarrio",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Barrio",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
