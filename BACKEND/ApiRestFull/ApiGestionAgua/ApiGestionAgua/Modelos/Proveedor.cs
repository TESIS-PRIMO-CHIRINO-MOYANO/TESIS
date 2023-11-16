﻿using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
