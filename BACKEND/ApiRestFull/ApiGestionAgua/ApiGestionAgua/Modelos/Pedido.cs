using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Pedido
    {

        [Key]
        public int IdPedido { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal ImporteTotal { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        public int IdPatente { get; set; }

        [ForeignKey("IdPatente")]
        public Vehiculo Vehiculo { get; set; }

        public int IdZona { get; set; }

        [ForeignKey("IdZona")]
        public Zona Zona { get; set; }

        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }

    }
}
