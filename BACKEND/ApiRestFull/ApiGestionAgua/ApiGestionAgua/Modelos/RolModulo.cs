using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class RolModulo
    {
        
        public DateTime Fecha { get; set; }
    
        public int IdRol { get; set; }
        public Rol Rol { get; set; }

        public int IdModulo { get; set; }
        public Modulo Modulo { get; set; }

    }
}
