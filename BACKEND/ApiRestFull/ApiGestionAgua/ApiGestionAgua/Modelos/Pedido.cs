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

        [ForeignKey("IdCliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("IdPatente")]
        public int IdPatente { get; set; }

        public Vehiculo Vehiculo { get; set; }

        [ForeignKey("IdZona")]
        public int IdZona { get; set; }

        public Zona Zona { get; set; }

        [ForeignKey("IdEstado")]
        public int IdEstado { get; set; }

        public Estado Estado { get; set; }

    }
}
