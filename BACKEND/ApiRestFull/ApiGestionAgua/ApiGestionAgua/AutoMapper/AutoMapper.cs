using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using AutoMapper;

namespace ApiGestionAgua.AutoMapper
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<Producto, ProdutoDTO>().ReverseMap();
            
        }

    }
}
