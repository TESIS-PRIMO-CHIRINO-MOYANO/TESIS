using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IModuloRepositorio
    {

        ICollection<Modulo> GetModulos();

        Modulo GetModulo(int id);

        bool ExisteModulo(string Nombre);

        bool ExisteModulo(int IdModulo);

        bool CrearModulo(Modulo modulo);

        bool ActualizarModulo(Modulo modulo);

        bool BorrarModulo(Modulo modulo);

        bool Guardar();

    }
}
