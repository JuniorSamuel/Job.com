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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicios _categoriasServicios;
        public CategoriaController(ICategoriaServicios categoriasServicios)
        {
            _categoriasServicios = categoriasServicios;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriasServicios.GetCategoriasAsync();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoriaId:int}", Name ="GetCategoriaId")]
        public async Task<ActionResult<Categoria>> GetCategoriaByIdAsync(int categoriaId)
        {
            try
            {
                var categoria = await _categoriasServicios.GetCategoriasByIdAsync(categoriaId);
                if (categoria != null)
                    return Ok(categoria);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> AddCategoriaAsync(Categoria categoria)
        {
            try
            {
                var guardarCategoria = await _categoriasServicios.AddCategoriasAsync(categoria);
                return CreatedAtRoute("GetCategoriaId", new { categoriaId = guardarCategoria.IdCategoria },
                    guardarCategoria);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> UpdateCategoriaAsync(Categoria categoria)
        {
            try
            {
                var ActualiCategoria = await _categoriasServicios.UpdateCategoriaAsync(categoria);
                return Ok(ActualiCategoria);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategoriaAsync(int CategoriaId)
        {
            try
            {
                await _categoriasServicios.DeleteCategoriaAsync(CategoriaId);
                return Ok("Categoria eliminado Satisfactoriamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

