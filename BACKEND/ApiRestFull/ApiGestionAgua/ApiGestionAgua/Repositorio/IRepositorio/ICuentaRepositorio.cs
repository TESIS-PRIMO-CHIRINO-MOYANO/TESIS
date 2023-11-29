using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface ICuentaRepositorio
    {

        ICollection<CuentaCorriente> GetCuentaCorrientes();

        CuentaCorriente GetCuentaCorriente(int id);

        bool ExisteCuentaCorriente(int IdCuenta);

        bool CrearCuentaCorriente(CuentaCorriente cuentaCorriente);

        bool ActualizarCuentaCorriente(CuentaCorriente cuentaCorriente);

        bool BorrarCuentaCorriente(CuentaCorriente cuentaCorriente);

        bool Guardar();

    }
}
