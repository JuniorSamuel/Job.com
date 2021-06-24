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
        public async Task<ActionResult<Categoria>> GetCategoriaByIdAsync(int CategoriaId)
        {
            try
            {
                var categoria = await _categoriasServicios.GetCategoriasByIdAsync(CategoriaId);
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
                return CreatedAtRoute("GetCategoriaId", new { CategoriaId = guardarCategoria.IdCategoria },
                    guardarCategoria);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

