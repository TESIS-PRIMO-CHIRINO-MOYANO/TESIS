using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/compra")]

    public class CompraController : ControllerBase
    {

        private readonly ICompraRepositorio _cRepo;
        private readonly IMapper _mapper;

        public CompraController(ICompraRepositorio cRepo, IMapper mapper)
        {
            _cRepo = cRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetCompras()
        {
            var ListaCompra = _cRepo.GetCompras();

            var ListaCompraDTO = new List<CompraDTO>();

            foreach (var lista in ListaCompra)
            {
                ListaCompraDTO.Add(_mapper.Map<CompraDTO>(lista));
            }
            return Ok(ListaCompraDTO);

        }

        [HttpGet("{IdCompra:int}", Name = "GetCompra")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetCompra(int IdCompra)
        {
            var itemCompra = _cRepo.GetCompra(IdCompra);

            if (itemCompra == null)
            {
                return NotFound();
            }
            var itemCompraDTO = _mapper.Map<CompraDTO>(itemCompra);
            return Ok(itemCompraDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CompraDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearCompra([FromBody] CompraDTO compraDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (compraDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_cRepo.ExisteCompra(compraDTO.IdCompra))
            {
                ModelState.AddModelError("", "La la compra ya existe");
                return BadRequest(ModelState);
            }

            var compra = _mapper.Map<Compra>(compraDTO);
            if (!_cRepo.CrearCompra(compra))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {compra.IdCompra}");
                return StatusCode(500, ModelState);
            }
            var compraCreadaDTO = _mapper.Map<CompraDTO>(compra);

            return CreatedAtRoute("GetCompra", new { IdCompra = compra.IdCompra }, compraCreadaDTO);

        }

        [HttpPatch("{IdCompra:int}", Name = "ActualizarCompra")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(CompraDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarCompra(int IdCompra, [FromBody] CompraDTO compraDTO)
        {

            if (!ModelState.IsValid || compraDTO == null || compraDTO.IdCompra != IdCompra)
            {
                return BadRequest(ModelState);
            }


            var compra = _mapper.Map<Compra>(compraDTO);
            if (!_cRepo.ActualizarCompra(compra))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {compra.IdCompra}");
                return StatusCode(500, ModelState);
            }
            var CompraCreadaDTO = _mapper.Map<CompraDTO>(compra);

            return NoContent();

        }

        [HttpDelete("{IdCompra:int}", Name = "BorrarCompra")]
        [ProducesResponseType(201, Type = typeof(CompraDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarCompra(int IdCompra)
        {
            if (!_cRepo.ExisteCompra(IdCompra))
            {
                return NotFound();
            }
            var compra = _cRepo.GetCompra(IdCompra);
            if (!_cRepo.BorrarCompra(compra))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {compra.IdCompra}");
                return StatusCode(500, ModelState);
            }
            var CompraCreadaDTO = _mapper.Map<CompraDTO>(compra);

            return NoContent();

        }

    }
}
