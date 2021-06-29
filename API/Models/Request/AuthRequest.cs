using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}
