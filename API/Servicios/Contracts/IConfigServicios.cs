using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface IConfigServicios
    {
        Task<List<Config>> GetConfigAsync();
        Task<Config> UpdateConfigAsync(Config config);

    }
}
