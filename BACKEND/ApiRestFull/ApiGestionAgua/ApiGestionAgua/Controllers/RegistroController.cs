using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionAgua.Controllers
{

    [Route("api/registro")]
    [ApiController]
    public class RegistroController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRegistroRepositorio _RRepo;

        public RegistroController(IRegistroRepositorio RRepo, IMapper mapper)
        {
            _RRepo = RRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(RegistroClienteDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CrearUsuario([FromBody] RegistroClienteDTO registroClienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (registroClienteDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_RRepo.ExisteUsuario(registroClienteDTO.Mail,registroClienteDTO.Dni))
            {
                ModelState.AddModelError("", "El Usuario ya existe");
                return BadRequest(ModelState);
            }

            if (!_RRepo.CrearUsuario(registroClienteDTO))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el usuario {registroClienteDTO.Nombre}");
                return StatusCode(500, ModelState);
            }

            if (!_RRepo.CrearCliente(registroClienteDTO))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el cliente.");
                return StatusCode(500, ModelState);
            }

            if (!_RRepo.CrearCuenta(registroClienteDTO))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando la cuenta.");
                return StatusCode(500, ModelState);
            }

            return Ok();

        }

    }
}
