﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    /// <inheritdoc />
    public partial class CreacionRamaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Insumo",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Insumo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");
        }
    }
}
