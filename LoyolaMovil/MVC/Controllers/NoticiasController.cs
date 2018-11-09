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
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public ActionResult Noticias()
        {
            var NotBLL= new NoticiaBLL();
            List<tblNoticia> listaNoticias = NotBLL.RetrieveAll();

            var lvlBLL = new NivelBLL();
            tblNivel objLvl;

            vmListaNoticias objTemp;

            List<vmListaNoticias> listaFinal = new List<vmListaNoticias>();

            foreach (var i in listaNoticias)
            {
                objLvl = lvlBLL.RetrieveNivelByID(i.idNivel);
                string nivelNombre = objLvl.nivelNombre;

                objTemp = new vmListaNoticias()
                {
                    idNoticias = i.idNoticias,
                    noticiasTitulo = i.noticiasTitulo,
                    noticiasTexto = i.noticiasTexto,
                    idNivel = nivelNombre
                };
                listaFinal.Add(objTemp);
            }

            return View(listaFinal);
        }

        
        // GET: Noticias/Create
        public ActionResult Create()
        {
            ViewBag.Nombre = "Texto desde el controlador";
            return View();
        }

        // POST: Noticias/Create
        [HttpPost]
        public ActionResult Create(tblNoticia Noticias)
        {
            var NotBLL = new NoticiaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    NotBLL.Create(Noticias);
                    Result = RedirectToAction("Noticias");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Noticias/Edit/5
        public ActionResult Edit(int id)
        {
            var NotBLL = new NoticiaBLL();
            tblNoticia objNot = NotBLL.RetrieveNoticiaByID(id);

            return View(objNot);
        }

        // POST: Noticias/Edit/5
        [HttpPost]
        public ActionResult Edit(tblNoticia Noticias)
        {
            var NotBLL = new NoticiaBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    NotBLL.Update(Noticias);
                    Result = RedirectToAction("Noticias");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Noticias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Noticias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
