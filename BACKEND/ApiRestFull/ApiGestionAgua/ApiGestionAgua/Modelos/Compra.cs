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
        public DateTime Fecha { get; set; }

        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [ForeignKey("IdProveedor")]
        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; }

        [ForeignKey("IdInsumo")]
        public int IdInsumo { get; set; }

        public Insumo Insumo { get; set; }

    }
}
