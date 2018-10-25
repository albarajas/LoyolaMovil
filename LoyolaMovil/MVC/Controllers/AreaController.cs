using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            var areaBLL = new AreasBLL();
            List<tblArea> listaAreas = areaBLL.RetrieveAll();

            return View(listaAreas);
        }

        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(tblArea area)
        {
            var areaBLL = new AreasBLL();
            ActionResult Result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    areaBLL.Create(area);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return Result;
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            var areaBLL = new AreasBLL();
            tblArea objArea = areaBLL.RetrieveAreaByID(id);
            return View(objArea);
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(tblArea area)
        {
            var areaBLL = new AreasBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    areaBLL.Update(area);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Area/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Area/Delete/5
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