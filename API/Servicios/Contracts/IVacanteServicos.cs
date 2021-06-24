using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface IVacanteServicios
    {
        Task<List<Vacante>> GetVacantesAsync();
        Task<List<Vacante>> GetVacantesByCategoriaAsync(int CategoriaId);
        Task<Vacante> GetVacanteByIdAsync(int VacanteId);
        Task<Vacante> AddVacanteAsync(Vacante vacante);
        Task<Vacante> UpdateVacanteAsync(Vacante vacante);
        Task DeleteVacanteAsync(int VacanteId);
    }
}
