using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Response
{
    public class UserResponse
    {
        public int IdUsuario { get; set; }
        public int? IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? Cedula { get; set; }
        public decimal? Telefono { get; set; }
        public string Correo { get; set; }

        public string Token { get; set; }
    }
}
