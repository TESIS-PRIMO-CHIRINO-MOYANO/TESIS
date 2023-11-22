﻿using System.ComponentModel.DataAnnotations;

namespace ApiGestionAgua.Modelos
{
    public class Estado
    {

        [Key]
        public int IdEstado { get; set; }

        [Required]
        public string Nombre { get; set; }

    }
}