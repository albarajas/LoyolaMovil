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
    public class NivelController : Controller
    {
        // GET: Nivel
        public ActionResult Index()
        {
            var lvlBLL = new NivelBLL();
            List < tblNivel> listaNivel = lvlBLL.RetrieveAll();

            return View(listaNivel);
        }

        // GET: Nivel/Create
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Nivel/Create
        [HttpPost]
        public ActionResult Create(tblNivel nivel)
        {
            var lvlBLL = new NivelBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    lvlBLL.Create(nivel);
                    Result = RedirectToAction("Index");
                }
                else
                {
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                Result = RedirectToAction("Index");

            }
            return Result;
        }
        // GET: Nivel/Edit/5
        public ActionResult Edit(int id)
        {
            var lvlBLL = new NivelBLL();
            tblNivel objlvl = lvlBLL.RetrieveNivelByID(id);

            return View(objlvl);
        }

        // POST: Nivel/Edit/5
        [HttpPost]
        public ActionResult Edit(tblNivel nivel)
        {
            var lvlBLL = new NivelBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    lvlBLL.Update(nivel);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return Result;
        }

        // GET: Nivel/Delete/5
        public JsonResult DeleteNivel(int id)
        {
            var lvlBLL = new NivelBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblNivel nivel = lvlBLL.RetrieveNivelByID(id);

                if (nivel != null)
                {
                    bool banderita = lvlBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El nivel se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El nivel NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El nivel no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar elnivel";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }


    }
}
