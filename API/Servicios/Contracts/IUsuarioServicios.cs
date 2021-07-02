using API.Models;
using API.Models.Request;
using API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Contracts
{
    public interface IUsuarioServicios
    {
        UserResponse Auth(AuthRequest model);

        Task<List<Usuario>> GetUsuariosAsync();
        Task<List<Usuario>> GetUsuariosByRolAsync(int RolId);
        Task<Usuario> GetUsuarioByIdAsync(int UsuarioId);
        Task<Usuario> AddUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int UsuarioId);

    }
}
