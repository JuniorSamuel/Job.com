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
    public class CategoriaServicios : ICategoriaServicios
    {
        private readonly APIDbContext _dbContext;
        public CategoriaServicios(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Categoria> AddCategoriasAsync(Categoria categoria)
        {
            try
            {
                await _dbContext.Categorias.AddAsync(categoria);
                await _dbContext.SaveChangesAsync();
                return categoria;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            try
            {
                var Categorias = await _dbContext.Categorias.ToListAsync();
                return Categorias;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> GetCategoriasByIdAsync(int CategoriaId)
        {
            try
            {
                var Categoria = await _dbContext.Categorias.Where(c => c.IdCategoria == CategoriaId).FirstOrDefaultAsync();
                return Categoria;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {
            try
            {
                if (categoria.IdCategoria > 0)
                {
                    _dbContext.Entry(categoria).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return categoria;
                }

                throw new Exception("Categoria no encontrado");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCategoriaAsync(int CategoriaId)
        {
            try
            {
                var Categoria = await GetCategoriasByIdAsync(CategoriaId);
                if (Categoria != null)
                {
                    _dbContext.Set<Categoria>().Remove(Categoria);
                    //_dbContext.Categoria.Remove(Vacante);
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
