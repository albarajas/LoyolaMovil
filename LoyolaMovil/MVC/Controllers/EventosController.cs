using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index()
        {
            var eveBLL = new EventoBLL();
            List<tblEvento> listaEventos = eveBLL.RetrieveAll();

            return View(listaEventos);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        public ActionResult Create(tblEvento evento)
        {
            var eveBLL = new EventoBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    eveBLL.Create(evento);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int id)
        {
            var eveBLL = new EventoBLL();
            tblEvento objEve = eveBLL.RetrievEventoByID(id);

            return View(objEve);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        public ActionResult Edit(tblEvento evento)
        {
            var eveBLL = new EventoBLL();
            ActionResult Result = null;

            try
            {
                if(ModelState.IsValid)
                {
                    eveBLL.Update(evento);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Eventos/Delete/5
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
