using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class MedioPago
    {

        [Key]
        public int IdMedioPago { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}
