using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace ApiGestionAgua.Controllers
{

    [Route("api/registro")]
    [ApiController]
    public class RegistroController : ControllerBase
    {

        private readonly IMapper _mapper;
        protected RespuestaAPI _respuestaAPI;
        private readonly IRegistroRepositorio _RRepo;

        public RegistroController(IRegistroRepositorio RRepo, IMapper mapper)
        {
            _RRepo = RRepo;
            this._respuestaAPI = new();
            _mapper = mapper;
        }

        [HttpPost("crearUsuario")]
        [ProducesResponseType(201, Type = typeof(RegistroClienteDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CrearUsuario([FromBody] RegistroClienteDTO registroClienteDTO)
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
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("El usuario ya existe.");
                return BadRequest(_respuestaAPI);
            }

            var usuario = await _RRepo.CrearUsuario(registroClienteDTO);
            if (usuario == null) 
            {
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error en el registro usuario.");
                return BadRequest(_respuestaAPI);
            }      

            if (!_RRepo.CrearCliente(registroClienteDTO))
            {
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error en el registro cliente.");
                return BadRequest(_respuestaAPI);
            }

            if (!_RRepo.CrearCuenta(registroClienteDTO))
            {
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("Error en el registro cuenta.");
                return BadRequest(_respuestaAPI);
            }

            _respuestaAPI.statusCode = HttpStatusCode.OK;
            _respuestaAPI.IsSucces = true;
            return Ok(_respuestaAPI);

        }

    }
}
