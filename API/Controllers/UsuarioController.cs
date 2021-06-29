using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Servicios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using API.Models.Request;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicios _usuarioServicios;
        public UsuarioController(IUsuarioServicios usuarioServicios)
        {
            _usuarioServicios = usuarioServicios;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var userResponse = _usuarioServicios.Auth(model);

            if (userResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o Contrasena incorrecto";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _usuarioServicios.GetUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId:int}", Name ="GetUsuarioId")]
        public async Task<ActionResult<Usuario>> GetUsuariosByIdAsync(int UsuarioId)
        {
            try
            {
                var usuario = await _usuarioServicios.GetUsuarioByIdAsync(UsuarioId);
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
        public async Task<ActionResult<List<Usuario>>> GetUsuariosByRolAsync(int RolId)
        {
            try
            {
                var usuarios = await _usuarioServicios.GetUsuariosByRolAsync(RolId);
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

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                