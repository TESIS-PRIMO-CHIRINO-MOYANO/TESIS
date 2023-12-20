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

        public int IdMedioPago { get; set; }

        [ForeignKey("IdMedioPago")]
        public MedioPago MedioPago { get; set; }

        public int IdCuenta { get; set; }

        [ForeignKey("IdCuenta")]
        public CuentaCorriente cuentaCorriente { get; set; }

    }
}
