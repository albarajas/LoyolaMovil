using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class TipoAulaController : Controller
    {
        // GET: TipoAula
        public ActionResult Index()
        {
            var taBLL = new TipoAulaBLL();
            List<tblTipoAula> listaTipoAula = taBLL.RetrieveAll();

            return View(listaTipoAula);
        }

        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: TipoAula/Create
        [HttpPost]
        public ActionResult Create(tblTipoAula ta)
        {
            var taBLL = new TipoAulaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    taBLL.Create(ta);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: TipoAula/Edit/5
        public ActionResult Edit(int id)
        {
            var taBLL = new TipoAulaBLL();
            tblTipoAula objTa = taBLL.RetrieveTipoAulaByID(id);

            return View(objTa);
        }

        // POST: TipoAula/Edit/5
        [HttpPost]
        public ActionResult Edit(tblTipoAula ta)
        {
            var taBLL = new TipoAulaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    taBLL.Update(ta);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: TipoAula/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoAula/Delete/5
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