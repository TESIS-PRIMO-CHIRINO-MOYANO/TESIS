using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface ILineaRepositorio
    {
        ICollection<Linea> GetLineas();

        Linea GetLinea(int id);

        bool ExisteLinea(string Nombre);

        bool ExisteLinea(int IdLinea);
        bool CrearLinea(Linea linea);

        bool ActualizarLinea(Linea linea);

        bool BorrarLinea(Linea linea);

        bool Guardar();
    }
}
