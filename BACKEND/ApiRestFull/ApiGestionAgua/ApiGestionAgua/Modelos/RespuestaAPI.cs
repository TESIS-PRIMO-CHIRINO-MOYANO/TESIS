using System.Net;
using System.Runtime.InteropServices.ObjectiveC;

namespace ApiGestionAgua.Modelos
{
    public class RespuestaAPI
    {

        public RespuestaAPI()
        {
            ErrorMessages = new List<string>();

        }

        public HttpStatusCode statusCode { get; set; }
        public bool IsSucces { get; set; } = true;
        public List<string> ErrorMessages { get; set;}

        public object Result { get; set; }

    }
}
