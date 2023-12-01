﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestionAgua.Modelos
{
    public class Cliente
    {

        [Key]
        public int IdCliente { get; set; }

        [Required]
        public string Calle { get; set; }

        [Required]
        public string Piso { get; set; }

        [Required]
        public string Depto { get; set; }

        [Required]
        public string Telefono { get; set; }


        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        
        public int IdBarrio { get; set; }

        [ForeignKey("IdBarrio")]
        public Barrio barrio { get; set; }

    }
}
