using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class ColaboradorController : Controller
    {
        public ActionResult Index()
        {
            var colBLL = new ColaboradorBLL();
            List<tblColaboradore> listaColaboradores = colBLL.RetrieveAll();

            return View(listaColaboradores);
        }


        // GET: Colaborador/Create
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        public ActionResult Create(tblColaboradore colaborador)
        {
            var colBLL = new ColaboradorBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    colBLL.Create(colaborador);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public ActionResult Edit(int id)
        {
            var colBLL = new ColaboradorBLL();
            tblColaboradore objCol = colBLL.RetrieveColaboradorByID(id);

            return View(objCol);
        }

        [HttpPost]
        public ActionResult Edit(tblColaboradore colaborador)
        {
            var colBLL = new ColaboradorBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    colBLL.Update(colaborador);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Colaborador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Colaborador/Delete/5
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
