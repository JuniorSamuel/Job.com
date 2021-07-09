using API.Controllers;
using API.Models;
using API.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebasAPI.PruebasUnitarias
{
    [TestClass]
    public class PruebaCategoriaController : BasePruebas
    {
        [TestMethod]
        public async Task GetCategoriasAsync()
        {
            //Preparacion
            var nombreDB = Guid.NewGuid().ToString(); //Crea un nombre aleatorio para la Base de Datos
            var contexto = ConstruirContext(nombreDB); 

            contexto.Categorias.Add(new Categoria { Nombre = "Categoria de Prueba" });
            contexto.Categorias.Add(new Categoria { Nombre = "Categoria 2" });
            await contexto.SaveChangesAsync();

            
            var categoriasServicios = new CategoriaServicios(contexto);

            //Ejecucion
            var Controller = new CategoriaController(categoriasServicios);
            var respuesta = await Controller.GetCategoriasAsync();

            //Verificacion
            var categorias = respuesta;
            Assert.AreEqual(2, categorias);
        }

        public List<Categoria> GetTest()
        {
            var testCategoria = new List<Categoria>();
            testCategoria.Add(new Categoria { IdCategoria = 1, Nombre = "Categoria de Prueba" });
            testCategoria.Add(new Categoria { IdCategoria = 2, Nombre = "Categoria 2" });

            return testCategoria;
        }
    }
}
