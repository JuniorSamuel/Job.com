using API.Models;
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
        public async Task<ActionResult<Solicitud>> GetSolicitudByIdAsync(int SolicitudId)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByIdAsync(SolicitudId);

                if (solicitud != null) 
                    return Ok(solicitud);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiltroPorUsuario/{usuarioId:int}")]
        public async Task<ActionResult<List<Solicitud>>> GetSolicitudByUsuarioAsync(int UsuarioId)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByUsuarioAsync(UsuarioId);
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("FiltroPorVacante/{vacanteId:int}")]
        public async Task<ActionResult<List<Solicitud>>> GetSolicitudByVacanteAsync(int VacanteId)
        {
            try
            {
                var solicitud = await _solicitudServicios.GetSolicitudByVacanteAsync(VacanteId);
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
        public async Task<ActionResult> DeleteSolicitudAsync(int SolicitudId)
        {
            try
            {
                await _solicitudServicios.DeleteSolicitudAsync(SolicitudId);
                return Ok("Solicitud eliminado Satisfactoriamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
