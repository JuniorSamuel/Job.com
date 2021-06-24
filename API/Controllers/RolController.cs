using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Servicios.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetRolsAsync()
        {
            try
            {
                var rols = await _rolService.GetRolsAsync();
                return Ok(rols);
            }
            catch(Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpGet("{RolId:int}", Name = "GetRol")]
        public async Task<ActionResult<Rol>> GetRolByIdAsync(int RolId)
        {
            try
            {
                var rol = await _rolService.GetRolByIdAsync(RolId);
                if (rol != null) 
                    return Ok(rol);
                return NotFound();
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> AddRolAsync(Rol rol)
        {
            try
            {

                var guardarRol = await _rolService.AddRolAsync(rol);
                return CreatedAtRoute("GetRol", new { RolId = guardarRol.IdRol }, 
                    guardarRol);

            }catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        } 
    }
}
