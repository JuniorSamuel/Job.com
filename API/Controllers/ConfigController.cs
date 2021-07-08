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
    public class ConfigController : ControllerBase
    {
        private  readonly IConfigServicios _ConfigServicios;
        public ConfigController(IConfigServicios configServicios)
        {
            _ConfigServicios = configServicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<Config>>> GetConfigAsync()
        {
            try
            {
                var Config = await _ConfigServicios.GetConfigAsync();
                return Ok(Config);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Config>> UpdateConfigAsync(Config Config)
        {
            try
            {
                var ActualiC = await _ConfigServicios.UpdateConfigAsync(Config);
                return Ok(ActualiC);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

