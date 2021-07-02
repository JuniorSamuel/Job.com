using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Servicios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VacanteController : ControllerBase
    {
        private readonly IVacanteServicios _vacantesServicios;
        public VacanteController(IVacanteServicios vacanteServicios)
        {
            _vacantesServicios = vacanteServicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vacante>>> GetVacantesAsync()
        {
            try
            {
                var vacantes = await _vacantesServicios.GetVacantesAsync();
                return Ok(vacantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{vacanteId:int}", Name ="GetVacanteId")]
        public async Task<ActionResult<Vacante>> GetVacanteByIdAsync(int VacanteId)
        {
            try
            {
                var vacante = await _vacantesServicios.GetVacanteByIdAsync(VacanteId);
                if (vacante != null)
                    return Ok(vacante);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FiltroPorCategoria/{categoriaId:int}")]
        public async Task<ActionResult<List<Vacante>>> GetVacantesByCategoriaAsync(int CategoriaId)
        {
            try
            {
                var vacantes = await _vacantesServicios.GetVacantesByCategoriaAsync(CategoriaId);
                return Ok(vacantes);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Vacante>> AddVacanteAsync(Vacante vacante)
        {
            try
            {
                var guardarVacante = await _vacantesServicios.AddVacanteAsync(vacante);
                return CreatedAtRoute("GetVacanteId", new { VacanteId = guardarVacante.IdVacante },
                    guardarVacante);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Vacante>> UpdateVacanteAsync(Vacante vacante)
        {
            try
            {
                var ActualiVacante = await _vacantesServicios.UpdateVacanteAsync(vacante);
                return Ok(ActualiVacante);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteVacanteAsync(int VacanteId)
        {
            try
            {
                await _vacantesServicios.DeleteVacanteAsync(VacanteId);
                return Ok("Vacante eliminado Satisfactoriamente");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                