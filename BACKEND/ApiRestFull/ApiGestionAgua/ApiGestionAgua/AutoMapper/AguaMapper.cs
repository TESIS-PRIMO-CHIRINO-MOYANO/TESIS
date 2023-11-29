using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using AutoMapper;

namespace ApiGestionAgua.AutoMapper
{
    public class AguaMapper : Profile
    {

        public AguaMapper()
        {

            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Linea, LineaDTO>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<Barrio, BarrioDTO>().ReverseMap();
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            CreateMap<Insumo, InsumoDTO>().ReverseMap();
            CreateMap<Zona, ZonaDTO>().ReverseMap();
            CreateMap<Estado, EstadoDTO>().ReverseMap();
        }

    }
}
