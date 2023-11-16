using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Pago
    {

        [Key]
        public int IdPago { get; set; }   

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Pagado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdMedioPago")]
        public int IdMedioPago { get; set; }

        public MedioPago MedioPago { get; set; }

    }
}
