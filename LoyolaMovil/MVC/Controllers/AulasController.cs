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
            var aulasBLL = new AulaBLL();
            List<tblAula> listaAulas = aulasBLL.RetrieveAll();

            var tipoAulaBLL = new TipoAulaBLL();
            tblTipoAula objTipoAula;

            var edificioBLL = new EdificioBLL();
            tblEdificio objEdificio;

            //creo un objeto de la vm para almacenar temporalmente los registros....
            vmListaAulas objTemp;

            //creo una lista vm para almacenar los objetos....
            List<vmListaAulas> listaFinal = new List<vmListaAulas>();

            foreach (var i in listaAulas)
            {
                objTipoAula = tipoAulaBLL.RetrieveTipoAulaByID(i.idTipoAula);
                string nombreTipoAula = objTipoAula.tipoAula;

                objEdificio = edificioBLL.RetrieveEdificioByID(i.idEdificio);
                string nombreEdificio = objEdificio.nombreEdificio;

                objTemp = new vmListaAulas()
                {
                    idAula = i.idAula,
                    nombreAula = i.nombreAula,
                    idTipoAula = nombreTipoAula,
                    idEdificio = nombreEdificio,
                };

                listaFinal.Add(objTemp);
            }


            return View(listaFinal);
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

        public JsonResult DeleteAula(int id)
        {
            var aulBLL = new AulaBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblAula aula = aulBLL.RetrieveAulaByID(id);

                if (aula != null)
                {
                    var auBLL = new AulaBLL();
                    List<tblAula> listaAulas = auBLL.RetrieveAulaTipoAulaByID(id);

                    if (listaAulas.Count() >= 0)
                    {
                        //significa que tiene Aulas....
                    }

                    bool banderita = aulBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El Aula se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El Aula NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El Aula no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el Registro";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
    }
}
