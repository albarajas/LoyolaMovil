using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;
using MVC.Models;

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
        public JsonResult DeleteTipoAula(int id)
        {
            var taBLL = new TipoAulaBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblTipoAula tipoaula = taBLL.RetrieveTipoAulaByID(id);

                if (tipoaula != null)
                {
                    var auBLL = new AulaBLL();
                    List<tblAula> listaAulas = auBLL.RetrieveAulaTipoAulaByID(id);

                    if (listaAulas.Count() >= 0)
                    {
                        //significa que tiene Aulas....
                    }

                    bool banderita = taBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El Tipo Aula se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El Tipo Aula NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El Tipo Aula no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el Tipo Aula";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

    }
}