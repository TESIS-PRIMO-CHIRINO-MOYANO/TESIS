using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IRegistroRepositorio
    {

        Usuario GetUsuario(string Dni);
        Cliente GetCliente(int IdUsuario);
        CuentaCorriente GetCuenta(int IdCliente);
        bool ExisteUsuario(string Mail, string Dni);
        Task<Usuario> CrearUsuario(RegistroClienteDTO registroClienteDTO);
        bool CrearCliente(RegistroClienteDTO registroClienteDTO);
        bool CrearCuenta(RegistroClienteDTO registroClienteDTO);
        bool Guardar();

    }
}
