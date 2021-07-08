using API.Controllers;
using API.Models;
using API.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace PruebasAPI.PruebasUnitarias
{
    [TestClass]
    public class PruebaCategoriaController : BasePruebas
    {
        [TestInitialize]


        [TestMethod]
        public async Task GetCategoriasAsync()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString(); //Crea un nombre aleatorio para la Base de Datos
            var contexto = ConstruirContext(nombreDB);

            contexto.Categorias.Add(new Categoria { Nombre = "Categoria de Prueba" });
            contexto.Categorias.Add(new Categoria { Nombre = "Categoria 2" });
            await contexto.SaveChangesAsync();

            //var contexto2 = ConstruirContext(nombreDB);
            var categoriasServicios = new CategoriaServicios(contexto);

            //Ejecucion
            var ID = 1;
            var Controller = new CategoriaController(categoriasServicios);
            var respuesta = await Controller.GetCategoriaByIdAsync(ID);

            //Verificacion
            var categorias = respuesta.Value;
            Assert.AreEqual(ID, categorias.IdCategoria);
        }
    }
}
