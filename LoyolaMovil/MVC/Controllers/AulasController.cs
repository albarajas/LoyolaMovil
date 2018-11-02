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
            var ediBLL = new EdificioBLL();
            List<tblEdificio> listaEdificios = ediBLL.RetrieveAll();
            ViewBag.idEdificio = new SelectList(listaEdificios, "idEdificio", "nombreEdificio");

            var ti_auBLL = new TipoAulaBLL();
            List<tblTipoAula> listaTipoAula = ti_auBLL.RetrieveAll();
            ViewBag.idTipoAula = new SelectList(listaTipoAula, "idTipoAula", "tipoAula");

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
            var ediBLL = new EdificioBLL();
            List<tblEdificio> listaEdificios = ediBLL.RetrieveAll();
            ViewBag.idEdificio = new SelectList(listaEdificios, "idEdificio", "nombreEdificio", objCol.idEdificio);


            var ti_auBLL = new TipoAulaBLL();
            List<tblTipoAula> listaTipoAula = ti_auBLL.RetrieveAll();
            ViewBag.idTipoAula = new SelectList(listaTipoAula, "idTipoAula", "tipoAula", objCol.idTipoAula);


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
