using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;
using MVC.Models;

namespace MVC.Controllers
{
    public class GeneralesController : Controller
    {
        // Seccion correspondiente al manejo de los dias.....

        public ActionResult IndexDias()
        {
            var diasBLL = new DiaBLL();
            List<tblDías> listaDias = diasBLL.RetrieveAll();

            return View(listaDias);
        }

        public ActionResult CreateDias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDias(tblDías dia)
        {
            var diasBLL = new DiaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    diasBLL.Create(dia);
                    Result = RedirectToAction("IndexDias");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public ActionResult EditDias(int id)
        {
            var diasBLL = new DiaBLL();
            tblDías objdia = diasBLL.RetrieveDiaByID(id);

            return View(objdia);
        }

        [HttpPost]
        public ActionResult EditDias(tblDías dia)
        {
            var diasBLL = new DiaBLL();
            ActionResult Result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    diasBLL.Update(dia);
                    Result = RedirectToAction("IndexDias");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public JsonResult DeleteDias(int id)
        {
            var diasBLL = new DiaBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblDías dia = diasBLL.RetrieveDiaByID(id);

                if (dia != null)
                {
                    var citaBLL = new CitaBLL();
                    List<tblCita> listaCitas = citaBLL.RetrieveCitaDiaByID(id);

                    if (listaCitas.Count() >= 0)
                    {
                        //Tiene Citas
                    }

                    bool banderita = diasBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El dia se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El dia NO se eliminó correctamente";
                    }
                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El dia no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el dia";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

        //fin de la seccion del manejo de dias......


        //inicio de la seccion del manejo de las semanassç

        public ActionResult IndexSemanas()
        {
            var semBLL = new SemanasBLL();
            List<tblSemana> listaSemanas = semBLL.RetrieveAll();

            return View(listaSemanas);
        }

        public ActionResult CreateSemanas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSemanas(tblSemana semana)
        {
            var semBLL = new SemanasBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    semBLL.Create(semana);
                    Result = RedirectToAction("IndexSemanas");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public ActionResult EditSemanas(int id)
        {
            var semBLL = new SemanasBLL();
            tblSemana objsem = semBLL.RetrieveSemanaByID(id);

            return View(objsem);
        }

        [HttpPost]
        public ActionResult EditSemanas(tblSemana semana)
        {
            var semBLL = new SemanasBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    semBLL.Update(semana);
                    Result = RedirectToAction("IndexSemanas");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public JsonResult DeleteSemanas(int id)
        {
            var semBLL = new SemanasBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblSemana semana = semBLL.RetrieveSemanaByID(id);

                if (semana != null)
                {
                    var citaBLL = new CitaBLL();
                    List<tblCita> listaCitas = citaBLL.RetrieveCitasSemanaByID(id);

                    if (listaCitas.Count() >= 0)
                    {
                        //Tiene Citas
                    }

                    bool banderita = semBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "La semana se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "La semana NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "La semana no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar la semana";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }

        // fin de la seccion del maejo de las semasna....


        //Inicio e la seccion del manejo de anio.....
        //
        public ActionResult IndexAnio()
        {
            var anioBLL = new AnioBLL();
            List<tblAnio> listaAnio = anioBLL.RetrieveAll();

            return View(listaAnio);
        }

        public ActionResult CreateAnio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAnio(tblAnio anio)
        {
            var anioBLL = new AnioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    anioBLL.Create(anio);
                    Result = RedirectToAction("IndexAnio");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public ActionResult EditAnio(int id)
        {
            var anioBLL = new AnioBLL();
            tblAnio objanio = anioBLL.RetrieveAnioByID(id);

            return View(objanio);
        }

        [HttpPost]
        public ActionResult EditAnio(tblAnio anio)
        {
            var anioBLL = new AnioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    anioBLL.Update(anio);
                    Result = RedirectToAction("IndexAnio");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        public JsonResult DeleteAnio(int id)
        {
            var anioBLL = new AnioBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblAnio anio = anioBLL.RetrieveAnioByID(id);

                if (anio != null)
                {
                    var semBLL = new SemanasBLL();
                    List<tblSemana> listaSemana = semBLL.RetrieveSemanaAnioByID(id);

                    if (listaSemana.Count() >= 0)
                    {
                        //Tiene Semanas
                    }

                    bool banderita = anioBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El anio se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El anio NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El anio no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el anio";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
    }
}