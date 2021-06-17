using System;
using System.Collections.Generic;

#nullable disable

namespace API_JOB.Modelo
{
    public partial class Vacante
    {
        public Vacante()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdVacante { get; set; }
        public int IdCategoria { get; set; }
        public string Compania { get; set; }
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        public string Horario { get; set; }
        public string Descripcion { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
