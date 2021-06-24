using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface IRolService
    {
        Task<List<Rol>> GetRolsAsync();
        Task<Rol> GetRolByIdAsync(int RolId);
        Task<Rol> AddRolAsync(Rol rol);

    }
}
