using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class modificacionTablaClienteUsuarioCuenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CuentaCorriente_IdCuenta",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdCuenta",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdCuenta",
                table: "Cliente");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "CuentaCorriente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorriente_IdCliente",
                table: "CuentaCorriente",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCorriente_Cliente_IdCliente",
                table: "CuentaCorriente",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCorriente_Cliente_IdCliente",
                table: "CuentaCorriente");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCorriente_IdCliente",
                table: "CuentaCorriente");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "CuentaCorriente");

            migrationBuilder.AddColumn<int>(
                name: "IdCuenta",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCuenta",
                table: "Cliente",
                column: "IdCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CuentaCorriente_IdCuenta",
                table: "Cliente",
                column: "IdCuenta",
                principalTable: "CuentaCorriente",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
