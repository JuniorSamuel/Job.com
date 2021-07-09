using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Servicios.Contracts;
using API.DbContexts;
using Microsoft.EntityFrameworkCore;
using API.Models.Request;
using API.Tools;
using API.Models.Response;
using API.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using API.Respuestas;

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

            var usuario = _dbContext.Usuarios.Where(d=>d.Correo == model.Correo && d.Contrasena==contrasena).FirstOrDefault();

            if (usuario == null) return null;
            userResponse.IdUsuario = usuario.IdUsuario;
            userResponse.IdRol = usuario.IdRol;
            userResponse.Nombre = usuario.Nombre;
            userResponse.Apellido = usuario.Apellido;
            userResponse.Cedula= usuario.Cedula;
            userResponse.Telefono = usuario.Telefono;
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
                usuario.Contrasena = Encrypt.GetSHA256(usuario.Contrasena);
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

        private async Task<Usuario> GetUsuarioByIdCompletoAsync(int UsuarioId)
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
        public async Task<Usuario> GetUsuarioByIdAsync(int UsuarioId)
        {
            try
            {
                var Usuario = await _dbContext.Usuarios.Where(u => u.IdUsuario == UsuarioId).FirstOrDefaultAsync();
                if (Usuario == null) return null;
                var UsuarioSinCont = new Usuario
                {
                    IdUsuario = Usuario.IdUsuario,
                    IdRol = Usuario.IdRol,
                    Nombre = Usuario.Nombre,
                    Apellido = Usuario.Apellido,
                    Correo = Usuario.Correo,
                    Cedula = Usuario.Cedula,
                    Telefono = Usuario.Telefono
                };
                return UsuarioSinCont;
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

        public async Task<Usuario> UpdateUsuarioAsync(Usuario _usuario)
        {
            try
            {
                var usuario = new Usuario();
                usuario.IdUsuario = _usuario.IdUsuario;
                usuario.Nombre = _usuario.Nombre;
                usuario.IdRol = _usuario.IdRol;
                usuario.Apellido = _usuario.Apellido;
                usuario.Correo = _usuario.Correo;
                usuario.Cedula = _usuario.Cedula;
                usuario.Telefono = _usuario.Telefono;

                _dbContext.Usuarios.Attach(usuario);
                _dbContext.Entry(usuario).Property( x => x.Nombre).IsModified =true;
                _dbContext.Entry(usuario).Property(x => x.Apellido).IsModified = true;
                _dbContext.Entry(usuario).Property(x => x.IdRol).IsModified = true;
                _dbContext.Entry(usuario).Property(x => x.Cedula).IsModified = true;
                _dbContext.Entry(usuario).Property(x => x.Correo).IsModified = true;
                _dbContext.Entry(usuario).Property(x => x.Telefono).IsModified = true;
                _dbContext.SaveChanges();


                return usuario;
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
                var Usuario = await GetUsuarioByIdCompletoAsync(UsuarioId);
                if(Usuario != null)
                {
                    //_dbContext.Set<Usuario>().Remove(Usuario);
                    _dbContext.Usuarios.Remove(Usuario);
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

