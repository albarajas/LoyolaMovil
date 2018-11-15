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
        /// <summary>
        /// Este metodo va a crear una lista del modelo vmListaAreas
        /// y tengo que ir a la BD a tomar los registros y despues
        /// construir la lista manualmente....
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var areaBLL = new AreasBLL();
            List<tblArea> listaAreas = areaBLL.RetrieveAll();

            var colBLL = new ColaboradorBLL();
            tblColaboradore objCol;

            var aulaBLL = new AulaBLL();
            tblAula objAula;

            //creo un objeto de la vm para almacenar temporalmente los registros....
            vmListaAreas objTemp;

            //creo una lista vm para almacenar los objetos....
            List<vmListaAreas> listaFinal = new List<vmListaAreas>();

            foreach(var i in listaAreas)
            {
                objCol = colBLL.RetrieveColaboradorByID(i.idColaborador);
                string nombreColaborador = objCol.nombreColaborador;

                objAula = aulaBLL.RetrieveAulaByID(i.idAula);
                string nombreAula = objAula.nombreAula;

                objTemp = new vmListaAreas()
                {
                    idArea = i.idArea,
                    nombreArea = i.nombreArea,
                    horaInicio = i.horaInicio.ToShortTimeString(),
                    horaFinal = i.horaFinal.ToShortTimeString(),
                    idColaborador = nombreColaborador,
                    idAula = nombreAula
                };

                listaFinal.Add(objTemp);
            }


            return View(listaFinal);
        }

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

            var aulaBLL = new AulaBLL();
            List<tblAula> listaAulas = aulaBLL.RetrieveAll();
            ViewBag.idAula = new SelectList(listaAulas, "idAula", "nombreAula", objArea.idAula);

            var colaboradorBLL = new ColaboradorBLL();
            List<tblColaboradore> listacolaborador = colaboradorBLL.RetrieveAll();
            ViewBag.idColaborador = new SelectList(listacolaborador, "idcolaborador", "nombreColaborador", objArea.idColaborador);


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
                    
                    bool banderita = aerBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El Area se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El Area NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El Area no se encontró";
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