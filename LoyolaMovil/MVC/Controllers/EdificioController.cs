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
        public JsonResult DeleteNoticias(int id)
        {
            var NotBLL = new NoticiaBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblNoticia noticia = NotBLL.RetrieveNoticiaByID(id);

                if (noticia != null)
                {

                    bool banderita = NotBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "La noticia se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "La noticia NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "La noticia no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar la noticia";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

    }

}
