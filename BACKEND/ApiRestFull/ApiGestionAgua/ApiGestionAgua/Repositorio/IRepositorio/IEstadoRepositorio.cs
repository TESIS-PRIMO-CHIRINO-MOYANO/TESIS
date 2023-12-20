using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IEstadoRepositorio
    {
        ICollection<Estado> GetEstados();
        Estado GetEstado(int id);
        bool ExisteEstado(string Nombre);
        bool ExisteEstado(int IdEstado);
        bool CrearEstado(Estado estado);
        bool ActualizarEstado(Estado estado);
        bool BorrarEstado(Estado estado);
        bool Guardar();
    }
}
