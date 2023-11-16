using ApiGestionAgua.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionAgua.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        //agregar modelos aca
        public DbSet<Producto> Producto { get; set; }

        public DbSet<Linea> Linea { get; set; }

        public DbSet<Vehiculo> Vehiculo { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Insumo> Insumo { get; set; }

        public DbSet<MedioPago> MedioPago { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<Zona> Zona { get; set; }

        public DbSet<Barrio> Barrio { get; set; }

        public DbSet<Compra> Compra { get; set; }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<RolModulo> RolModulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relaciones de la tabla rol modulo
            modelBuilder.Entity<RolModulo>()
                .HasKey(tr => new { tr.IdRol, tr.IdModulo });

            modelBuilder.Entity<RolModulo>()
                .HasOne(tr => tr.Rol)
                .WithMany()
                .HasForeignKey(tr => tr.IdRol);

            modelBuilder.Entity<RolModulo>()
                .HasOne(tr => tr.Modulo)
                .WithMany()
                .HasForeignKey(tr => tr.IdModulo);


            //realciones de la tabla producto pedido
            modelBuilder.Entity<ProductoPedido>()
                .HasKey(tr => new { tr.IdPedido, tr.IdProducto });

            modelBuilder.Entity<ProductoPedido>()
                .HasOne(tr => tr.Pedido)
                .WithMany()
                .HasForeignKey(tr => tr.IdPedido);

            modelBuilder.Entity<ProductoPedido>()
                .HasOne(tr => tr.Producto)
                .WithMany()
                .HasForeignKey(tr => tr.IdProducto);
        }  

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Pago> Pago { get; set; }

        public DbSet<CuentaCorriente> CuentaCorriente { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<ProductoPedido> ProductoPedido { get; set; }

    }
}
