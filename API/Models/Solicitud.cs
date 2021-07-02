using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace API.Models
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int? UsuarioId { get; set; }
        public int? VacanteId { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vacante IdVacanteNavigation { get; set; }
    }
}
