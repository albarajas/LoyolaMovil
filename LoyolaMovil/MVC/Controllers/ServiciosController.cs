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
    public class ServiciosController : Controller
    {
        // GET: Servicios
        public ActionResult Index()
        {
            var serBLL = new ServiciosBLL();
            List<tblServicio> listaServicios = serBLL.RetrieveAll();

            return View(listaServicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        public ActionResult Create(tblServicio servicio)
        {
            var serBLL = new ServiciosBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    serBLL.Create(servicio);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return Result;
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int id)
        {
            var serBLL = new ServiciosBLL();
            tblServicio objSer = serBLL.RetrieveServicioByID(id);

            return View(objSer);
        }

        // POST: Servicios/Edit/5
        [HttpPost]
        public ActionResult Edit(tblServicio servicio)
        {
            var serBLL = new ServiciosBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    serBLL.Update(servicio);
                    Result = RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
            return Result;
        }
        public JsonResult DeleteServicio(int id)
        {
            var serBLL = new ServiciosBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblServicio servicio = serBLL.RetrieveServicioByID(id);

                if (servicio != null)
                {

                    bool banderita = serBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El Servicio se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El Servicio NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El Servicio no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el Servicio";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
    }
}