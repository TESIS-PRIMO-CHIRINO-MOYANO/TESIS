using ApiGestionAgua.Modelos;

namespace ApiGestionAgua.Repositorio.IRepositorio
{
    public interface IZonaRepositorio
    {
        ICollection<Zona> GetZonas();

        Zona GetZona(int id);
        bool ExisteZona(string zona);

        bool ExisteZona(int IdZona);

        bool CrearZona(Zona zona);

        bool ActualizarZona(Zona zona);

        bool BorrarZonar(Zona zona);

        bool Guardar();

    }
}
