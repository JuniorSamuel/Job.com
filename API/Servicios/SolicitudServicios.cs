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

        public async Task<Solicitud> GetSolicitudByIdAsync(int idSolicitud)
        {
             try
             {
                var solicitud = await _dbContext.Solicitudes.Where(s => s.IdSolicitud == idSolicitud).FirstOrDefaultAsync();

                return solicitud;
             }
            catch
             {
                throw;
             }
        }

        public async Task<List<Solicitud>> GetSolicitudByUsuarioAsync(int usuarioId)
        {
            try
            {
                var solicitud = await _dbContext.Solicitudes.Where(s => s.UsuarioId == usuarioId).ToListAsync();

                return solicitud;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Solicitud>> GetSolicitudByVacanteAsync(int vacanteId)
        {
            try
            {
                 var solicitud = await _dbContext.Solicitudes.Where(s => s.VacanteId == vacanteId).ToListAsync();

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

                throw new Exception("La solicitud no fue actualizada");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteSolicitudAsync(int idSolicitud)
        {
            try
            {
                var solicitud = await GetSolicitudByIdAsync(idSolicitud);
                if (solicitud != null)
                {
                    _dbContext.Solicitudes.Remove(solicitud);
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
