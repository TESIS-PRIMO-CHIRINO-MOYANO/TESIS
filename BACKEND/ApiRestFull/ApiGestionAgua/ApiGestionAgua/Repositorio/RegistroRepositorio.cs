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

        public bool CrearCliente(RegistroClienteDTO registroClienteDTO)
        {
            var usuario = GetUsuario(registroClienteDTO.Dni);

            var cliente = new Cliente
            {
                Calle = registroClienteDTO.Calle,
                Piso = registroClienteDTO.Piso,
                Depto = registroClienteDTO.Depto,
                Telefono = registroClienteDTO.Telefono,
                IdUsuario = usuario.IdUsuario,
                IdBarrio = registroClienteDTO.IdBarrio
            };

            _bd.Cliente.Add(cliente);
            return Guardar();
        }

        public bool CrearCuenta(RegistroClienteDTO registroClienteDTO)
        {
            var usuario = GetUsuario(registroClienteDTO.Dni);
            var cliente = GetCliente(usuario.IdUsuario);


            var Cuenta = new CuentaCorriente
            {
                Monto = 0,
                IdCliente = cliente.IdCliente
                
            };

            _bd.CuentaCorriente.Add(Cuenta);
            return Guardar();
        }

        public Usuario GetUsuario(string Dni)
        {
            return _bd.Usuario.FirstOrDefault(u => u.Dni == Dni);
        }


        public Cliente GetCliente(int IdUsuario)
        {
            return _bd.Cliente.FirstOrDefault(c => c.IdUsuario == IdUsuario);
        }

        public CuentaCorriente GetCuenta(int IdCliente)
        {
            return _bd.CuentaCorriente.FirstOrDefault(c => c.IdCliente == IdCliente);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public async Task<Usuario> CrearUsuario(RegistroClienteDTO registroClienteDTO) 
        {
        
            var passwordEncriptado = obtenermd5(registroClienteDTO.Password);

            Usuario usuario = new Usuario()
            {
                Dni = registroClienteDTO.Dni,
                Nombre = registroClienteDTO.Nombre,
                Apellido = registroClienteDTO.Apellido,
                IdRol = registroClienteDTO.IdRol,
                FechaNacimiento = (DateTime)registroClienteDTO.FechaNacimiento,
                Mail = registroClienteDTO.Mail,
                FechaAlta = DateTime.Now,
                Password = passwordEncriptado
            };

            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            return usuario;
        
        }

        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }


    }
}
