using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IClienteLoginRepositorio
    {

        Usuario GetUsuario(int usuarioId);

        Task<ClienteLoginRespuestaDTO> Login(ClienteLoginDTO clienteLoginDTO);

        

    }
}
