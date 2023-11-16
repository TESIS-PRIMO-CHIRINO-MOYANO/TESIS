using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Insumo
    {
        [Key]
        public int IdInsumo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Precio { get; set; }
    }
}
