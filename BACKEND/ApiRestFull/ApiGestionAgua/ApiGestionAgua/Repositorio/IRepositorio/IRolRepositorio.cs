using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IRolRepositorio
    {

        ICollection<Rol> GetRoles();

        Rol GetRol(int id);

        bool ExisteRol(string Nombre);

        bool ExisteRol(int IdRol);

        bool CrearRol(Rol rol);

        bool ActualizarRol(Rol rol);

        bool BorrarRol(Rol rol);

        bool Guardar();

    }
}
