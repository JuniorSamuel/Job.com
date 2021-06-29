using API.Models.Request;
using API.Servicios.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServicios _usuarioServicios;
        public LoginController(IUsuarioServicios usuarioServicios)
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
    }
}
