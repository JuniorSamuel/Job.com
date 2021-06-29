using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace API.Models
{
    public partial class Vacante
    {
        public Vacante()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int IdVacante { get; set; }
        public int? IdCategoria { get; set; }
        public string Compania { get; set; }
        public string Posicion { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }
        public decimal? Telefono { get; set; }
        public string Correo { get; set;}
        public string Ubicacion { get; set; }
        public DateTimeOffset Fecha { get; set; }


        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Solicitud> Solicituds { get; set; }

    }
}
