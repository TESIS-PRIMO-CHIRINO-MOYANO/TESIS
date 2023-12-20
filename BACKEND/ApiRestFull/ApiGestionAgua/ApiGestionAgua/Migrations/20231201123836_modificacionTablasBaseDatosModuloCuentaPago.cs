using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class modificacionTablasBaseDatosModuloCuentaPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuentaCorriente_Pago_IdPago",
                table: "CuentaCorriente");

            migrationBuilder.DropTable(
                name: "RolModulo");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropIndex(
                name: "IX_CuentaCorriente_IdPago",
                table: "CuentaCorriente");

            migrationBuilder.DropColumn(
                name: "IdPago",
                table: "CuentaCorriente");

            migrationBuilder.AddColumn<int>(
                name: "IdCuenta",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdCuenta",
                table: "Pago",
                column: "IdCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_CuentaCorriente_IdCuenta",
                table: "Pago",
                column: "IdCuenta",
                principalTable: "CuentaCorriente",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_CuentaCorriente_IdCuenta",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_IdCuenta",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "IdCuenta",
                table: "Pago");

            migrationBuilder.AddColumn<int>(
                name: "IdPago",
                table: "CuentaCorriente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdModulo);
                });

            migrationBuilder.CreateTable(
                name: "RolModulo",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolModulo", x => new { x.IdRol, x.IdModulo });
                    table.ForeignKey(
                        name: "FK_RolModulo_Modulo_IdModulo",
                        column: x => x.IdModulo,
                        principalTable: "Modulo",
                        principalColumn: "IdModulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolModulo_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorriente_IdPago",
                table: "CuentaCorriente",
                column: "IdPago");

            migrationBuilder.CreateIndex(
                name: "IX_RolModulo_IdModulo",
                table: "RolModulo",
                column: "IdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_CuentaCorriente_Pago_IdPago",
                table: "CuentaCorriente",
                column: "IdPago",
                principalTable: "Pago",
                principalColumn: "IdPago",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
