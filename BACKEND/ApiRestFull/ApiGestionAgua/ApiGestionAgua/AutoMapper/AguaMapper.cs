﻿using ApiGestionAgua.Modelos;
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
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            CreateMap<Insumo, InsumoDTO>().ReverseMap();

        }

    }
}
