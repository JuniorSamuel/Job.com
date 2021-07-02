using API.DbContexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Servicios.Contracts
{
    public class RolService : IRolService
    {
        private readonly APIDbContext _dbContext;
        public RolService(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Rol> AddRolAsync(Rol rol)
        {
            try
            {
                await _dbContext.Roles.AddAsync(rol);
                await _dbContext.SaveChangesAsync();
                return rol;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Rol>> GetRolsAsync()
        {
            try
            {
                var Rols = await _dbContext.Roles.ToListAsync();
                return Rols;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Rol> GetRolByidAsync(int RolId)
        {
            try
            {
                var Rol = await _dbContext.Roles.Where(R => R.IdRol == RolId).FirstOrDefaultAsync();
                return Rol;
            }
            catch
            {
                throw;
            }
        }
    }
}
