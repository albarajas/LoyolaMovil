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
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index()
        {
            var eveBLL = new EventoBLL();
            List<tblEvento> listaEventos = eveBLL.RetrieveAll();

            var lvlBLL = new NivelBLL();
            tblNivel objLvl;

            var ColBLL = new ColaboradorBLL();
            tblColaboradore objCol;

            var AulBLL = new AulaBLL();
            tblAula objAul;

            vmListaEventos objTemp;
            List<vmListaEventos> listaFinal = new List<vmListaEventos>();
            foreach (var i in listaEventos)
            {
                objLvl = lvlBLL.RetrieveNivelByID(i.idNivel);
                string nivelNombre = objLvl.nivelNombre;
                objCol = ColBLL.RetrieveColaboradorByID(i.idColaborador);
                string ColaboradorNombre = objCol.nombreColaborador;
                objAul = AulBLL.RetrieveAulaByID(i.idAula);
                string AulaNombre = objAul.nombreAula;
                objTemp = new vmListaEventos()
                {
                    idEvento = i.idEvento,
                    nombreEvento = i.nombreEvento,
                    descripcionEvento = i.descripcionEvento,
                    idNivel = nivelNombre,
                    idAula = AulaNombre,
                    idColaborador = ColaboradorNombre
                };
                listaFinal.Add(objTemp);
            }
            return View(listaFinal);

        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            var aulaBLL = new AulaBLL();
            List<tblAula> listaAulas = aulaBLL.RetrieveAll();
            ViewBag.idAula = new SelectList(listaAulas, "idAula", "nombreAula");

            var colaboradorBLL = new ColaboradorBLL();
            List<tblColaboradore> listacolaborador = colaboradorBLL.RetrieveAll();
            ViewBag.idColaborador = new SelectList(listacolaborador, "idcolaborador", "nombreColaborador");
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
            var aulaBLL = new AulaBLL();
            List<tblAula> listaAulas = aulaBLL.RetrieveAll();
            ViewBag.idAula = new SelectList(listaAulas, "idAula", "nombreAula", objEve.idAula);

            var colaboradorBLL = new ColaboradorBLL();
            List<tblColaboradore> listacolaborador = colaboradorBLL.RetrieveAll();
            ViewBag.idColaborador = new SelectList(listacolaborador, "idcolaborador", "nombreColaborador", objEve.idColaborador);

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
        public JsonResult DeleteEventos(int id)
        {
            var eveBLL = new EventoBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblEvento evento = eveBLL.RetrievEventoByID(id);

                if (evento != null)
                {

                    bool banderita = eveBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El evento se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El evento NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El evento no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el evento";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

    }
}
