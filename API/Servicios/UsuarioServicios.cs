using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Servicios.Contracts;
using API.DbContexts;
using Microsoft.EntityFrameworkCore;
using API.Models.Common;
using Microsoft.Extensions.Options;
using API.Models.Response;
using API.Models.Request;
using API.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace API.Servicios
{
    public class UsuarioServicios : IUsuarioServicios
    {
        private readonly APIDbContext _dbContext;
        private readonly AppSettings _appSettings;

        public UsuarioServicios(APIDbContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;

            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();

            string contrasena = Encrypt.GetSHA256(model.Contrasena);

            var usuario = _dbContext.Usuarios.Where(d => d.Correo == model.Correo && d.Contrasena == contrasena).FirstOrDefault();

            if (usuario == null) return null;
            userResponse.Correo = usuario.Correo;

            userResponse.Token = GetToken(usuario);


            return userResponse;
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Correo)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
