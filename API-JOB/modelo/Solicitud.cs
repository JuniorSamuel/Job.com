using System;
using System.Collections.Generic;

#nullable disable

namespace API_JOB.Modelo
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVacante { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vacante IdVacanteNavigation { get; set; }
    }
}
