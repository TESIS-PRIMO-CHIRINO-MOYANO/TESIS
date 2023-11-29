using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IBarrioRepositorio
    {
        ICollection<Barrio> GetBarrios();
        Barrio GetBarrio(int id);
        bool ExisteBarrio(string Nombre);
        bool ExisteBarrio(int IdBarrio);
        bool CrearBarrio(Barrio barrio);
        bool ActualizarBarrio(Barrio barrio);
        bool BorrarBarrio(Barrio barrio);
        bool Guardar();
    }
}
