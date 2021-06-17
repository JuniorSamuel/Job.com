using System;
using System.Collections.Generic;

#nullable disable

namespace API_JOB.Modelo
{
    public partial class Categorium
    {
        public Categorium()
        {
            Vacantes = new HashSet<Vacante>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
