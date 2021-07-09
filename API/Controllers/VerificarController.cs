using API.Models;
using API.Respuestas;
using API.Servicios.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VerificarController : ControllerBase
    {
        private readonly IUsuarioServicios _usuarioServicios;
        public VerificarController(IUsuarioServicios usuarioServicios)
        {
            _usuarioServicios = usuarioServicios;
        }

        // GET: api/<Verificar>
        [HttpGet]
        public async Task<bool> Get()
        {
            return  true;
        }

        // POST api/<Verificar>
        [HttpPost]
        public async Task<bool> Post([FromBody] Usuario value)
        {
            try
            {
                var usuarios = await _usuarioServicios.GetUsuarioByIdAsync(value.IdUsuario);
                if (usuarios == null) return false;
                if (value.IdRol != usuarios.IdRol) return false;
                if (value.Nombre != usuarios.Nombre) return false;
                if (value.Apellido != usuarios.Apellido) return false;
                if (value.Correo != usuarios.Correo) return false;
                if (value.Cedula != usuarios.Cedula) return false;
                if (value.Telefono != usuarios.Telefono) return false;
                
                
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
