using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{
    [ApiController]
    [Route("api/rol")]

    public class RolController : ControllerBase
    {

        private readonly IRolRepositorio _rRepo;
        private readonly IMapper _mapper;

        public RolController(IRolRepositorio rRepo, IMapper mapper)
        {
            _rRepo = rRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetRoles()
        {
            var ListaRol = _rRepo.GetRoles();

            var ListaRolDTO = new List<RolDTO>();

            foreach (var lista in ListaRol)
            {
                ListaRolDTO.Add(_mapper.Map<RolDTO>(lista));
            }
            return Ok(ListaRolDTO);

        }

        [HttpGet("{IdRol:int}", Name = "GetRol")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetRol(int IdRol)
        {
            var itemRol = _rRepo.GetRol(IdRol);

            if (itemRol == null)
            {
                return NotFound();
            }
            var itemRolDTO = _mapper.Map<RolDTO>(itemRol);
            return Ok(itemRolDTO);

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(RolDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearRol([FromBody] RolDTO rolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (rolDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_rRepo.ExisteRol(rolDTO.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return BadRequest(ModelState);
            }

            var rol = _mapper.Map<Rol>(rolDTO);
            if (!_rRepo.CrearRol(rol))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {rol.Nombre}");
                return StatusCode(500, ModelState);
            }
            var rolCreadoDTO = _mapper.Map<RolDTO>(rol);

            return CreatedAtRoute("GetRol", new { IdRol = rol.IdRol }, rolCreadoDTO);

        }

        [HttpPatch("{IdRol:int}", Name = "ActualizarRol")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(RolDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarRol(int IdRol, [FromBody] RolDTO rolDTO)
        {

            if (!ModelState.IsValid || rolDTO == null || rolDTO.IdRol != IdRol)
            {
                return BadRequest(ModelState);
            }


            var rol = _mapper.Map<Rol>(rolDTO);
            if (!_rRepo.ActualizarRol(rol))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {rol.Nombre}");
                return StatusCode(500, ModelState);
            }
            var rolCreadoDTO = _mapper.Map<RolDTO>(rol);

            return NoContent();

        }

        [HttpDelete("{IdRol:int}", Name = "BorrarRol")]//Este te deja actualizar parcialmente el put si osi tenes qu epasar todos los campos
        [ProducesResponseType(201, Type = typeof(RolDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BorrarRol(int IdRol)
        {

            if (!_rRepo.ExisteRol(IdRol))
            {
                return NotFound();
            }
            var rol = _rRepo.GetRol(IdRol);
            if (!_rRepo.BorrarRol(rol))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {rol.Nombre}");
                return StatusCode(500, ModelState);
            }
            var rolCreadoDTO = _mapper.Map<RolDTO>(rol);

            return NoContent();

        }

    }
}
