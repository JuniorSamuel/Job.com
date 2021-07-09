using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class verificarToken : Controller
    {
        // GET: verificarToken
        public ActionResult Index()
        {
            return View();
        }

        // GET: verificarToken/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: verificarToken/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: verificarToken/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: verificarToken/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: verificarToken/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: verificarToken/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: verificarToken/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
