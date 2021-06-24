using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Servicios.Contracts;
using API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios
{
    public class VacanteServicios : IVacanteServicios
    {
        private readonly APIDbContext _dbContext;
        public VacanteServicios(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Vacante> AddVacanteAsync(Vacante vacante)
        {
            try
            {
                await _dbContext.Vacantes.AddAsync(vacante);
                await _dbContext.SaveChangesAsync();
                return vacante;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<Vacante>> GetVacantesAsync()
        {
            try
            {
                var Vacantes = await _dbContext.Vacantes.ToListAsync();
                return Vacantes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Vacante> GetVacanteByIdAsync(int VacanteId)
        {
            try
            {
                var Vacantes = await _dbContext.Vacantes.Where(v => v.IdVacante == VacanteId).FirstOrDefaultAsync();
                return Vacantes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Vacante>> GetVacantesByCategoriaAsync(int CategoriaId)
        {
            try
            {
                var Vacantes = await _dbContext.Vacantes.Where(v => v.IdCategoria == CategoriaId).ToListAsync();
                return Vacantes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Vacante> UpdateVacanteAsync(Vacante vacante)
        {
            try
            {
                if(vacante.IdVacante > 0)
                {
                    _dbContext.Entry(vacante).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return vacante;
                }

                throw new Exception("Vacante no encontrado");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteVacanteAsync(int VacanteId)
        {
            try
            {
                var Vacante = await GetVacanteByIdAsync(VacanteId);
                if(Vacante != null)
                {
                    _dbContext.Set<Vacante>().Remove(Vacante);
                    //_dbContext.Vacantes.Remove(Vacante);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
