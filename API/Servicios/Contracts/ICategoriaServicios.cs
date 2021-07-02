using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface ICategoriaServicios
    {
        Task<List<Categoria>> GetCategoriasAsync();
        Task<Categoria> GetCategoriasByIdAsync(int CategoriaId);
        Task<Categoria> AddCategoriasAsync(Categoria categoria);
        Task<Categoria> UpdateCategoriaAsync(Categoria categoria);
        Task DeleteCategoriaAsync(int CategoriaId);
    }
}
