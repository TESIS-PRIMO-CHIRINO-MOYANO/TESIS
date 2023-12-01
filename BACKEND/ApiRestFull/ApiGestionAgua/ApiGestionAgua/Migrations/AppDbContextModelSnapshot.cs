﻿// <auto-generated />
using System;
using ApiGestionAgua.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiGestionAgua.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiGestionAgua.Modelos.Barrio", b =>
                {
                    b.Property<int>("IdBarrio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBarrio"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("IdZona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBarrio");

                    b.HasIndex("IdZona");

                    b.ToTable("Barrio");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Depto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBarrio")
                        .HasColumnType("int");

                    b.Property<int>("IdCuenta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Piso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdBarrio");

                    b.HasIndex("IdCuenta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("IdInsumo")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("ImporteTotal")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdCompra");

                    b.HasIndex("IdInsumo");

                    b.HasIndex("IdProveedor");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.CuentaCorriente", b =>
                {
                    b.Property<int>("IdCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCuenta"));

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdCuenta");

                    b.ToTable("CuentaCorriente");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Insumo", b =>
                {
                    b.Property<int>("IdInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInsumo"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdInsumo");

                    b.ToTable("Insumo");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Linea", b =>
                {
                    b.Property<int>("IdLinea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLinea"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdLinea");

                    b.ToTable("Linea");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.MedioPago", b =>
                {
                    b.Property<int>("IdMedioPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedioPago"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedioPago");

                    b.ToTable("MedioPago");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCuenta")
                        .HasColumnType("int");

                    b.Property<int>("IdMedioPago")
                        .HasColumnType("int");

                    b.Property<decimal>("Pagado")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdPago");

                    b.HasIndex("IdCuenta");

                    b.HasIndex("IdMedioPago");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdPatente")
                        .HasColumnType("int");

                    b.Property<int>("IdZona")
                        .HasColumnType("int");

                    b.Property<decimal>("ImporteTotal")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPatente");

                    b.HasIndex("IdZona");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdLinea")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(11,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdLinea");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.ProductoPedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("EsExtra")
                        .HasColumnType("bit");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdPedido", "IdProducto");

                    b.HasIndex("IdProducto");

                    b.ToTable("ProductoPedido");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Vehiculo", b =>
                {
                    b.Property<int>("IdPatente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatente"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPatente");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Zona", b =>
                {
                    b.Property<int>("IdZona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZona"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdZona");

                    b.ToTable("Zona");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Barrio", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Zona", "Zona")
                        .WithMany()
                        .HasForeignKey("IdZona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Cliente", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Barrio", "barrio")
                        .WithMany()
                        .HasForeignKey("IdBarrio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.CuentaCorriente", "CuentaCorriente")
                        .WithMany()
                        .HasForeignKey("IdCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaCorriente");

                    b.Navigation("Usuario");

                    b.Navigation("barrio");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Compra", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Insumo", "Insumo")
                        .WithMany()
                        .HasForeignKey("IdInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");

                    b.Navigation("Proveedor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Pago", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.CuentaCorriente", "cuentaCorriente")
                        .WithMany()
                        .HasForeignKey("IdCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.MedioPago", "MedioPago")
                        .WithMany()
                        .HasForeignKey("IdMedioPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedioPago");

                    b.Navigation("cuentaCorriente");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Pedido", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdPatente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Zona", "Zona")
                        .WithMany()
                        .HasForeignKey("IdZona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("Vehiculo");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Producto", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Linea", "Linea")
                        .WithMany()
                        .HasForeignKey("IdLinea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Linea");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.ProductoPedido", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiGestionAgua.Modelos.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ApiGestionAgua.Modelos.Usuario", b =>
                {
                    b.HasOne("ApiGestionAgua.Modelos.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
