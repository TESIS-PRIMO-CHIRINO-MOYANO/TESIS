using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IMedioPagoRepositorio
    {

        ICollection<MedioPago> GetMedioPagos();

        MedioPago GetMedioPago(int id);

        bool ExisteMedioPago(string Nombre);

        bool ExisteMedioPago(int IdMedioPago);

        bool CrearMedioPago(MedioPago medioPago);

        bool ActualizarMedioPago(MedioPago medioPago);

        bool BorrarMedioPago(MedioPago medioPago);

        bool Guardar();

    }
}
