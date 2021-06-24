using API.DbContexts;
using API.Models;
using API.Servicios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios
{
    public class SolicitudServicios : ISolicitudServicios
    {
        private readonly APIDbContext _dbContext;
        public SolicitudServicios(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Solicitud>> GetSolicitudAsync()
        {
            try
            {
                var solicitud = await _dbContext.Solicitudes.ToListAsync();
                return solicitud;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Solicitud> GetSolicitudByIdAsync(int SolicitudId)
        {
             try
             {
                var solicitud = await _dbContext.Solicitudes.Where(s => s.IdSolicitud == SolicitudId).FirstOrDefaultAsync();

                return solicitud;
             }
            catch
             {
                throw;
             }
        }

        public async Task<List<Solicitud>> GetSolicitudByUsuarioAsync(int UsuarioId)
        {
            try
            {
                var solicitud = await _dbContext.Solicitudes.Where(s => s.IdUsuario == UsuarioId).ToListAsync();

                return solicitud;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Solicitud>> GetSolicitudByVacanteAsync(int VacanteId)
        {
            try
            {
                 var solicitud = await _dbContext.Solicitudes.Where(s => s.IdVacante == VacanteId).ToListAsync();

                return solicitud;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Solicitud> AddSolicitudAsync(Solicitud solicitud)
        {
            try
            {
                await _dbContext.Solicitudes.AddAsync(solicitud);
                await _dbContext.SaveChangesAsync();
                return solicitud;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Solicitud> UpdateSolicitudAsync(Solicitud solicitud)
        {
            try
            {
                if (solicitud.IdSolicitud> 0)
                {
                    _dbContext.Entry(solicitud).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return solicitud;
                }

                throw new Exception("Solicitud no encontrada");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteSolicitudAsync(int SolicitudId)
        {
            try
            {
                var solicitud = await GetSolicitudByIdAsync(SolicitudId);
                if (solicitud != null)
                {
                    _dbContext.Set<Solicitud>().Remove(solicitud);
                    //_dbContext.Solicitudes.Remove(solicitud);
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
