using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using BLL;

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
        public ActionResult CreateDias(tblDías t)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch
                {

                }
            }
            return result;
        }

        public ActionResult EditDias(int id)
        {
            var diasBLL = new DiaBLL();
            tblDías objdia = diasBLL.RetrieveDiaByID(id);
            
            return View(objdia);
        }

        [HttpPost]
        public ActionResult EditDias(tblDías t)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch
                {

                }
            }
            return result;
        }

        public JsonResult DeleteDias(int id)
        {
           return Json("", JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateSemanas(tblSemana t)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch
                {

                }
            }
            return result;
        }

        public ActionResult EditSemanas(int id)
        {
            var diasBLL = new DiaBLL();
            tblDías objdia = diasBLL.RetrieveDiaByID(id);

            return View(objdia);
        }

        [HttpPost]
        public ActionResult EditSemanas(tblSemana t)
        {
            ActionResult result = null;
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch
                {

                }
            }
            return result;
        }

        public JsonResult DeleteSemanas(int id)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        // fin de la seccion del maejo de las semasna....


        // aqui ustedes van a poner lo demas.....
        //
    }
}
