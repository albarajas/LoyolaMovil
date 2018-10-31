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
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult Index()
        {
            var areaBLL = new AreasBLL();
            List<tblArea> listaAreas = areaBLL.RetrieveAll();

            return View(listaAreas);
        }

        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(tblArea area)
        {
            var areaBLL = new AreasBLL();
            ActionResult Result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    areaBLL.Create(area);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return Result;
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            var areaBLL = new AreasBLL();
            tblArea objArea = areaBLL.RetrieveAreaByID(id);
            return View(objArea);
        }

        // POST: Area/Edit/5
        [HttpPost]
        public ActionResult Edit(tblArea area)
        {
            var areaBLL = new AreasBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    areaBLL.Update(area);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public JsonResult DeleteArea(int id)
        {
            var aerBLL = new AreasBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblArea area = aerBLL.RetrieveAreaByID(id);

                if (area != null)
                {
                    var servBLL = new ServiciosBLL();
                    List<tblServicio> listaServicio = servBLL.RetrieveServicioAreaByID(id);

                    if (listaServicio.Count() >= 0)
                    {
                        //significa que tiene eventos....
                    }
                    var aer_servBLL = new Area_ServiciosBLL();
                    List<tblAreas_Servicios> listaAServicios = aer_servBLL.RetrieveAreas_ServicioAreaByID(id);

                    if (listaAServicios.Count() >= 0)
                    {
                        //significa que tiene areas asignadas....
                    }

                    bool banderita = aerBLL.Delete(id);

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