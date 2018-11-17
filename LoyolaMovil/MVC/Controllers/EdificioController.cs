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
    public class EdificioController : Controller
    {
        // GET: Edificio
        public ActionResult Index()
        {
            var ediBLL = new EdificioBLL();
            List<tblEdificio> listaEdificios = ediBLL.RetrieveAll();

            return View(listaEdificios);
        }

        // GET: Colaborador/Create
        public ActionResult Create()
        {
            


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
        public JsonResult DeleteEdificio(int id)
        {
            var ediBLL = new EdificioBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblEdificio edificio = ediBLL.RetrieveEdificioByID(id);

                if (edificio != null)
                {
                    var aulaBLL = new AulaBLL();
                    List<tblAula> listaAula = aulaBLL.RetrieveAulaEdificioByID(id);

                    if (listaAula.Count() >= 0)
                    {
                        //significa que tiene Aulas....
                    }

                    bool banderita = ediBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El edificio se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El edificio NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El edificio no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el edificio";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

    }

}
