using ApiGestionAgua.Data;
using ApiGestionAgua.Modelos;
using ApiGestionAgua.Modelos.Dtos;
using ApiGestionAgua.Repositorio.IRepositorio;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ApiGestionAgua.Repositorio
{
    public class ClienteLoginRepositorio : IClienteLoginRepositorio
    {
        private readonly AppDbContext _bd;
        private string claveSecreta;


        public ClienteLoginRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public Usuario GetUsuario(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteLoginRespuestaDTO> Login(ClienteLoginDTO clienteLoginDTO)
        {
            var passwordEncriptado = obtenermd5(clienteLoginDTO.Password);

            var usuario = _bd.Usuario.FirstOrDefault(

                u=>u.Mail.ToLower() == clienteLoginDTO.Mail.ToLower()
                && u.Password == passwordEncriptado

                );

            //validamos que el usuario no existe

            if (usuario == null) 
            {
                return new ClienteLoginRespuestaDTO()
                {
                    Token = "",
                    Usuario = null
                    
                };
            }

            //aqui existe el usuario, procesamos el login

            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject= new ClaimsIdentity(new Claim[] { 
                
                    new Claim(ClaimTypes.Name, usuario.Mail.ToString()),
                    new Claim(ClaimTypes.Role, "Cliente")    
                }),

                Expires=DateTime.UtcNow.AddDays(1),
                SigningCredentials =new (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadorToken.CreateToken(tokenDescription);

            ClienteLoginRespuestaDTO clienteLoginRespuestaDTO = new ClienteLoginRespuestaDTO()
            {
                Token= manejadorToken.WriteToken(token),
                Usuario = usuario
            };

            return clienteLoginRespuestaDTO;

        }

        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
