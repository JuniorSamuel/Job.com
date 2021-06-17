using System;
using System.Collections.Generic;

#nullable disable

namespace API_JOB.Modelo
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
