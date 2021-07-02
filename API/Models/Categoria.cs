using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace API.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Vacantes = new HashSet<Vacante>();
        }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Vacante> Vacantes { get; set; }

    }
}
