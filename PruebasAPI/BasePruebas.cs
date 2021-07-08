using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DbContexts;
using Microsoft.EntityFrameworkCore;
using API.Servicios.Contracts;
using API.Controllers;

namespace PruebasAPI
{
    public class BasePruebas
    {
        protected APIDbContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<APIDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var DbContext = new APIDbContext(opciones);

            return DbContext;
        }
    }
}
