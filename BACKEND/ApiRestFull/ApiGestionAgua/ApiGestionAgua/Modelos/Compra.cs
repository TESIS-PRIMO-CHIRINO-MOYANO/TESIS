using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Compra
    {

        [Key]
        public int IdCompra { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal ImporteTotal { get; set; }

        [Required]
        public DateTime? Fecha { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedor Proveedor { get; set; }

        public int IdInsumo { get; set; }

        [ForeignKey("IdInsumo")]
        public Insumo Insumo { get; set; }

    }
}
