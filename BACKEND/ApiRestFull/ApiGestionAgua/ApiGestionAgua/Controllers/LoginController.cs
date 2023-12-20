using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGestionAgua.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private readonly IMapper _mapper;
        protected RespuestaAPI _respuestaAPI;
        private readonly IClienteLoginRepositorio _cRepo;

        public LoginController(IClienteLoginRepositorio cRepo, IMapper mapper)
        {
            _cRepo = cRepo;
            this._respuestaAPI = new();
            _mapper = mapper;
        }

        [HttpPost("loginCliente")]
        [ProducesResponseType(201, Type = typeof(RegistroClienteDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> loginCliente([FromBody] ClienteLoginDTO clienteLoginDTO)
        {
            var respuestaLogin = await _cRepo.Login(clienteLoginDTO);

            
            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaAPI.statusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSucces = false;
                _respuestaAPI.ErrorMessages.Add("El usuario y/o contraseña son incorrectos.");
                return BadRequest(_respuestaAPI);
            }


            _respuestaAPI.statusCode = HttpStatusCode.OK;
            _respuestaAPI.IsSucces = true;
            _respuestaAPI.Result = respuestaLogin;
            return Ok(_respuestaAPI);

        }

    }
}
