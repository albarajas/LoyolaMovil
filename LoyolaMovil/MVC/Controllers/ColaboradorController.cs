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
    public class ColaboradorController : Controller
    {
        // GET: Edificio
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


        public JsonResult DeleteColaborador(int id)
        {
            var colBLL = new ColaboradorBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblColaboradore colaborador = colBLL.RetrieveColaboradorByID(id);

                if (colaborador != null)
                {
                    var eveBLL = new EventoBLL();
                    List<tblEvento> listaEventos = eveBLL.RetrieveEventosColaboradorByID(id);

                    if (listaEventos.Count() >= 0)
                    {
                        //significa que tiene eventos....
                    }

                    var areaBLL = new AreasBLL();
                    List<tblArea> listaArea = areaBLL.RetrieveAreasColaboradorByID(id);

                    if (listaArea.Count() >= 0)
                    {
                        //significa que tiene areas asignadas....
                    }

                    bool banderita = colBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El colaborador se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El colaborador NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El colaborador no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el registro";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
    }
}
