using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdUsuario { get; set; }
        public int? IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public decimal? Cedula { get; set; }
        public decimal? Telefono { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
