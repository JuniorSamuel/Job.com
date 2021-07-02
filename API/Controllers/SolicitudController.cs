using API.Models;
using API.Servicios.Contracts;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudServicios _solicitudServicios;
        public SolicitudController(ISolicitudServicios solicitudServicios)
        {
            _solicitudServicios = solicitudServicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<Solicitud>>> GetSolicitudAsync()
        {
            try
            {
                var solicitudes = await _solicitudServicios.GetSolicitudAsync();
                return Ok(solicitudes);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet ("{solicitudId:int}", Name = "GetSolicitudId")]
        public async Task<ActionResult<Solicitud>> GetSolicitudByIdAsync(int idSolicitud)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByIdAsync(idSolicitud);

                if (solicitud != null) return Ok(solicitud);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiltroPorUsuario/{usuarioId:int}")]
        public async Task<ActionResult<List<Solicitud>>> GetSolicitudByUsuarioAsync(int usuarioId)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByUsuarioAsync(usuarioId);
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("FiltroPorVacante/{vacanteId:int}")]
        public async Task<ActionResult<List<Solicitud>>> GetSolicitudByVacanteAsync(int vacanteId)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByVacanteAsync(vacanteId);
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Solicitud>> AddSolicitudAsync(Solicitud solicitud)
        {
            try
            {
                var guardarSolicitud = await _solicitudServicios.AddSolicitudAsync(solicitud);
                return CreatedAtRoute("GetSolicitudId", new { solicitudId = guardarSolicitud.IdSolicitud },
                    guardarSolicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Solicitud>> UpdateSolicitudAsync(Solicitud solicitud)
        {
            try
            {
                var ActualiSolicitud= await _solicitudServicios.UpdateSolicitudAsync(solicitud);
                return Ok(ActualiSolicitud);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSolicitudAsync(int idSolicitud)
        {
            try
            {
                await _solicitudServicios.DeleteSolicitudAsync(idSolicitud);
                return Ok("Solicitud eliminado Satisfactoriamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
