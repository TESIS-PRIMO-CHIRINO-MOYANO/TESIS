using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IRegistroRepositorio
    {

        Usuario GetUsuario(string Dni);
        bool ExisteUsuario(string Mail, string Dni);
        bool CrearUsuario(RegistroClienteDTO registroClienteDTO);

        bool Guardar();

    }
}
