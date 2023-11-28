using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IInsumoRepositorio
    {

        ICollection<Insumo> GetInsumos();

        Insumo GetInsumo(int id);

        bool ExisteInsumo(string Nombre);

        bool ExisteInsumo(int IdInsumo);
        bool CrearInsumo(Insumo insumo);

        bool ActualizarInsumo(Insumo insumo);

        bool BorrarInsumo(Insumo insumo);

        bool Guardar();

    }
}
