using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IVehiculoRepositorio
    {
        ICollection<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(int id);
        bool ExisteVehiculo(string Nombre);
        bool ExisteVehiculo(int IdVehiculo);
        bool CrearVehiculo(Vehiculo vehiculo);
        bool ActualizarVehiculo(Vehiculo vehiculo);
        bool BorrarVehiculo(Vehiculo vehiculo);       
        bool Guardar();
    }
}
