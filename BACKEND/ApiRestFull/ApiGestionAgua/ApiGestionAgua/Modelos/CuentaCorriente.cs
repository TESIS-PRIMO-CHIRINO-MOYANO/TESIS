using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class CuentaCorriente
    {

        [Key]
        public int IdCuenta { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Monto { get; set; }


    }
}
