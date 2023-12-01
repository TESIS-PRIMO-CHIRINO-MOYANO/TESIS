using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class CuentaCorriente
    {

        [Key]
        public int IdCuenta { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente cliente { get; set; }


        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Monto { get; set; }


    }
}
