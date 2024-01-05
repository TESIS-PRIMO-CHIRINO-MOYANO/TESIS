namespace ApiGestionAgua.Modelos.Dtos
{
    public class ClienteLoginRespuestaDTO
    {

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public CuentaCorriente Cuenta { get; set; }

        public string Token { get; set; }

    }
}
