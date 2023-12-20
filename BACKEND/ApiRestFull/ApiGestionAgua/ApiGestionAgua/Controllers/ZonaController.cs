using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [Route("api/zona")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IZonaRepositorio _zRepo;
        public ZonaController(IZonaRepositorio zRepo, IMapper mapper)
        {
            _zRepo = zRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetZonas()
        {
            var ListaZonas = _zRepo.GetZonas();
            var ListaZonasDTO = new List<ZonaDTO>();
            foreach (var lista in ListaZonas)
            {
                ListaZonasDTO.Add(_mapper.Map<ZonaDTO>(lista));
            }
            return Ok(ListaZonasDTO);
        }
        [HttpGet("{IdZona:int}", Name = "GetZona")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetZona(int IdZona)
        {
            var itemZona = _zRepo.GetZona(IdZona);
            if (itemZona == null)
            {
                return NotFound();
            }
            var itemZonaDTO = _mapper.Map<ZonaDTO>(itemZona);
            return Ok(itemZonaDTO);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LineaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearZona([FromBody] ZonaDTO zonaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (zonaDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_zRepo.ExisteZona(zonaDTO.Nombre))
            {
                ModelState.AddModelError("", "La zona ya existe");
                return BadRequest(ModelState);
            }
            var zona = _mapper.Map<Zona>(zonaDTO);
            if (!_zRepo.CrearZona(zona))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {zona.Nombre}");
                return StatusCode(500, ModelState);
            }
            var zonaCreadaDTO = _mapper.Map<ZonaDTO>(zona);
            return CreatedAtRoute("GetZona", new { IdZona = zona.IdZona }, zonaCreadaDTO);
        }
        [HttpPatch("{idZona:int}", Name = "ActualizarZona")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarZona(int idZona, [FromBody] ZonaDTO zonaDTO)
        {
            if (!ModelState.IsValid || zonaDTO == null || zonaDTO.IdZona != idZona)
            {
                return BadRequest(ModelState);
            }

            var zona = _mapper.Map<Zona>(zonaDTO);

            if (!_zRepo.ActualizarZona(zona))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {zona.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{idZona:int}", Name = "BorrarZona")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BorrarLinea(int idZona)
        {
            if (!_zRepo.ExisteZona(idZona))
            {
                return NotFound();
            }
            var zona = _zRepo.GetZona(idZona);
            if (!_zRepo.BorrarZonar(zona))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {zona.Nombre}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return NoContent();
        }
    }
}
