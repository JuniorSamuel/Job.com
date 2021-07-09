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
    public class ConfigServicios : IConfigServicios
    {
        private readonly APIDbContext _dbContext;
        public ConfigServicios(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Config>> GetConfigAsync()
        {
            try
            {
                var Config = await _dbContext.Configs.ToListAsync();
                return Config;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Config> UpdateConfigAsync(Config Config)
        {
            try
            {
                if (Config.IdConfig > 0)
                {
                    _dbContext.Entry(Config).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Config;
                }

                throw new Exception("Configuracion no encontrado");
            }
            catch
            {
                throw;
            }
        }
    }
}
