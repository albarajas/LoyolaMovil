using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class EdificioController : Controller
    {
        // GET: Edificio
        public ActionResult Index()
        {
            var ediBLL = new EdificioBLL();
            List<tblEdificio> listaEdificios = ediBLL.RetrieveAll();

            return View(listaEdificios);
        }
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Edificio/Create
        [HttpPost]
        public ActionResult Create(tblEdificio edificio)
        {
            var ediBLL = new EdificioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    ediBLL.Create(edificio);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Edificio/Edit/5
        public ActionResult Edit(int id)
        {
            var ediBLL = new EdificioBLL();
            tblEdificio objEdi = ediBLL.RetrieveEdificioByID(id);

            return View(objEdi);
        }

        // POST: Edificio/Edit/5
        [HttpPost]
        public ActionResult Edit(tblEdificio edificio)
        {
            var ediBLL = new EdificioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    ediBLL.Update(edificio);
                    Result = RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
            return Result;
        }

        // GET: Edificio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Edificio/Delete/5
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
