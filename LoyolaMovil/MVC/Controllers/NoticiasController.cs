﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

namespace MVC.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public ActionResult Noticias()
        {
            var NotBLL= new NoticiaBLL();
            List<tblNoticia> listaNoticias = NotBLL.RetrieveAll();

            return View(listaNoticias);
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
                    Result = RedirectToAction("Index");
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
                    Result = RedirectToAction("Index");
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