using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos.Dtos
{
    public class MedioPagoDTO
    {

        public int IdMedioPago { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

    }
}
