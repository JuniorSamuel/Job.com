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
    public class UsuarioServicios : IUsuarioServicios
    {
        private readonly APIDbContext _dbContext;
        public UsuarioServicios(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();
                return usuario;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var Usuarios = await _dbContext.Usuarios.ToListAsync();
                return Usuarios;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int UsuarioId)
        {
            try
            {
                var Usuario = await _dbContext.Usuarios.Where(u => u.IdUsuario == UsuarioId).FirstOrDefaultAsync();
                return Usuario;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Usuario>> GetUsuariosByRolAsync(int RolId)
        {
            try
            {
                var Usuarios = await _dbContext.Usuarios.Where(u => u.IdRol == RolId).ToListAsync();
                return Usuarios;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            try
            {
                if(usuario.IdUsuario > 0)
                {
                    _dbContext.Entry(usuario).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return usuario;
                }

                throw new Exception("Usuario no encontrado");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUsuarioAsync(int UsuarioId)
        {
            try
            {
                var Usuario = await GetUsuarioByIdAsync(UsuarioId);
                if(Usuario != null)
                {
                    _dbContext.Set<Usuario>().Remove(Usuario);
                    //_dbContext.Usuarios.Remove(Usuario);
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
