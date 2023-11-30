using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Cors;

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

        [HttpGet("{IdProducto:int}",Name = "GetProducto")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProducto(int IdProducto)
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
        [ProducesResponseType(201, Type = typeof(ProductoDTO))]
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
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var producto= _mapper.Map<Producto>(productoDTO);
            if (!_pRepo.CrearProducto(producto)) 
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {producto.Nombre}");
                return StatusCode(500, ModelState);
            }
            var productoCreadoDTO = _mapper.Map<ProductoDTO>(producto);

            return CreatedAtRoute("GetProducto", new { IdProducto = producto.IdProducto }, productoCreadoDTO);

        }
        
        [HttpPatch("{IdProducto:int}", Name = "ActualizarProducto")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public IActionResult ActualizarProducto(int IdProducto,[FromBody] ProductoDTO productoDTO)
        {
          
            if (!ModelState.IsValid || productoDTO == null || productoDTO.IdProducto != IdProducto)
            {
                return BadRequest(ModelState);
            }
            

            var producto = _mapper.Map<Producto>(productoDTO);
            if (!_pRepo.ActualizarProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {producto.Nombre}");
                return StatusCode(500, ModelState);
            }
            var productoCreadoDTO = _mapper.Map<ProductoDTO>(producto);

            return NoContent();

        }

        [HttpDelete("{IdProducto:int}", Name = "BorrarProducto")]
        [ProducesResponseType(201, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public IActionResult BorrarProducto(int IdProducto)
        {
            if (!_pRepo.ExisteProducto(IdProducto))
            { 
                return NotFound();
            }
            var producto = _pRepo.GetProducto(IdProducto);
            if (!_pRepo.BorrarProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {producto.Nombre}");
                return StatusCode(500, ModelState);
            }
            var productoCreadoDTO = _mapper.Map<ProductoDTO>(producto);

            return NoContent();

        }

    }
}
