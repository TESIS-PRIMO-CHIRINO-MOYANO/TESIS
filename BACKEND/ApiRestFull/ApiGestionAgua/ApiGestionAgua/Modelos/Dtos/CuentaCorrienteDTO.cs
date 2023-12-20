using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class CuentaCorrienteDTO
    {

        public int IdCuenta { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El pago es obligatorio.")]
        public int IdPago { get; set; }

    }
}
