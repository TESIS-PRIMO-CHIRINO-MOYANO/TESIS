using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Cliente
    {

        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Barrio { get; set; }

        [Required]
        public string Calle { get; set; }

        [Required]
        public string Piso { get; set; }

        [Required]
        public string Depto { get; set; }

        [Required]
        public string Telefono { get; set; }


        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [ForeignKey("IdCuenta")]
        public int IdCuenta { get; set; }

        public CuentaCorriente CuentaCorriente { get; set; }

    }
}
