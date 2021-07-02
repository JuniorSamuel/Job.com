using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Servicios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Request;
using Microsoft.AspNetCore.Authorization;
using API.Tools;
using API.Respuestas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicios _usuarioServicios;
        public UsuarioController(IUsuarioServicios usuarioServicios)
        {
            _usuarioServicios = usuarioServicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _usuarioServicios.GetUsuariosAsync();
                var UsuarioSinCont = usuarios.Select(x => new Usuario
                {
                    IdUsuario = x.IdUsuario,
                    IdRol = x.IdRol,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Correo = x.Correo,
                    Cedula = x.Cedula,
                    Telefono = x.Telefono
                });
                var respuesta = new ApiRespuesta<IEnumerable<Usuario>>(UsuarioSinCont);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId:int}", Name ="GetUsuarioId")]
        public async Task<ActionResult<Usuario>> GetUsuariosByIdAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioServicios.GetUsuarioByIdAsync(usuarioId);
                if (usuario != null)
                    return Ok(usuario);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiltroPorRol/{rolId:int}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosByRolAsync(int rolId)
        {
            try
            {
                var usuarios = await _usuarioServicios.GetUsuariosByRolAsync(rolId);
                return Ok(usuarios);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                var guardarUsuario = await _usuarioServicios.AddUsuarioAsync(usuario);
                return CreatedAtRoute("GetUsuarioId", new { usuarioId = guardarUsuario.IdUsuario },
                    guardarUsuario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateUsuarioAsync(Usuario usuario)
        {
            try
            {
                var ActualiUsuario = await _usuarioServicios.UpdateUsuarioAsync(usuario);
                return Ok(ActualiUsuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUsuarioAsync(int UsuarioId)
        {
            try
            {
                await _usuarioServicios.DeleteUsuarioAsync(UsuarioId);
                return Ok("Usuario eliminado Satisfactoriamente");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                