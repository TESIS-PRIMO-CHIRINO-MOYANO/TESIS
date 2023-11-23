﻿using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiGestionAgua.Controllers
{
    [ApiController]

    //[Route("api/[controller]")]// otra opcion
    [Route("api/producto")]

    //agregarmos controller base por que vamos a manejar solo la api no hace falta heredar todo lo de controller
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepositorio _pRepo;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepositorio pRepo, IMapper mapper)
        {
            _pRepo = pRepo;
            _mapper = mapper;

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProductos()
        {
            var ListaProducto = _pRepo.GetProductos();

            var ListaProductoDTO = new List<ProductoDTO>();

            foreach (var lista in ListaProducto) 
            {
                ListaProductoDTO.Add(_mapper.Map<ProductoDTO>(lista));
            }
            return Ok(ListaProductoDTO);

        }

        [HttpGet("{IdProducto:int}",Name = "GetProductos")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getProducto(int IdProducto)
        {
            var itemProducto = _pRepo.GetProducto(IdProducto);

            if (itemProducto == null)
            {
                return NotFound();
            }
            var itemProductoDTO = _mapper.Map<ProductoDTO>(itemProducto);
            return Ok(itemProductoDTO);

        }

        [HttpPost]
        [ProducesResponseType(201,Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            if (productoDTO==null) 
            {
                return BadRequest(ModelState);
            }
            if (_pRepo.ExisteProducto(productoDTO.Nombre)) 
            {
                ModelState.AddModelError("","El producto ya existe");
                return StatusCode(404, ModelState);
            }

            var producto= _mapper.Map<Producto>(productoDTO);
            if (!_pRepo.CrearProducto(producto)) 
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro{producto.Nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetProducto", new { productoId = producto.IdProducto }, producto);

        }


    }
}