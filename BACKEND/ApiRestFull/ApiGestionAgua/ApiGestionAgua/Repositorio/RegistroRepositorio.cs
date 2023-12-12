using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiGestionAgua.Repositorio
{
    public class RegistroRepositorio : IRegistroRepositorio
    {
        private readonly AppDbContext _bd;

        public RegistroRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }

        public bool ExisteUsuario(string Mail, string Dni)
        {
            bool valor = _bd.Usuario.Any(u => (u.Mail.ToLower().Trim() == Mail.ToLower().Trim()) && (u.Dni.ToLower().Trim() == Dni.ToLower().Trim()));

            return valor;
        }

        public bool CrearUsuario(RegistroClienteDTO registroClienteDTO)
        {
            var usuario = new Usuario
            {
                Dni = registroClienteDTO.Dni,
                Nombre = registroClienteDTO.Nombre,
                Apellido = registroClienteDTO.Apellido,
                IdRol = registroClienteDTO.IdRol,
                FechaNacimiento = (DateTime) registroClienteDTO.FechaNacimiento,
                Mail = registroClienteDTO.Mail,
                FechaAlta = DateTime.Now
            };

            _bd.Usuario.Add(usuario);
            return Guardar();

        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public Usuario GetUsuario(string Dni)
        {
            return _bd.Usuario.FirstOrDefault(u => u.Dni == Dni);
        }
    }
}
