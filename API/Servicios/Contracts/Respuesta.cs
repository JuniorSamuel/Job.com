using API.Models.Response;

namespace API.Servicios.Contracts
{
    public class Respuesta
    {
        public object Mensaje { get; internal set; }
        public int Exito { get; internal set; }
        public UserResponse Data { get; internal set; }
    }
}