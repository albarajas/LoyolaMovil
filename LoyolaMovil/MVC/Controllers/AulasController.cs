using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class AulasController : Controller
    {
        // GET: Aulas
        public ActionResult Index()
        {
            var AuBLL = new AulaBLL();
            List<tblAula> listaAulas = AuBLL.RetrieveAll();

            return View(listaAulas);
        }

        // GET: Aulas/Create
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Aulas/Create
        [HttpPost]
        public ActionResult Create(tblAula Aulas)
        {
            var AuBLL = new AulaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    AuBLL.Create(Aulas);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Aulas/Edit/5
        public ActionResult Edit(int id)
        {
            var AuBLL = new AulaBLL();
            tblAula objCol = AuBLL.RetrieveAulaByID(id);

            return View(objCol);
        }

        // POST: Aulas/Edit/5
        [HttpPost]
        public ActionResult Edit(tblAula Aulas)
        {
            var AuBLL = new AulaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    AuBLL.Update(Aulas);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Aulas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aulas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
