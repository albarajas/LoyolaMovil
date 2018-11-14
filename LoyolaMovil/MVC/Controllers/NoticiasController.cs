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
            var nivelBLL = new NivelBLL();
            List<tblNivel> listaNivel = nivelBLL.RetrieveAll();
            ViewBag.idNivel = new SelectList(listaNivel, "idNivel", "nivelNombre");

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
                else
                {
                    Result = RedirectToAction("Noticias");
                }
            }
            catch
            {
                Result = RedirectToAction("Noticias");

            }
            return Result;
        }

        // GET: Noticias/Edit/5
        public ActionResult Edit(int id)
        {
            var NotBLL = new NoticiaBLL();
            tblNoticia objNot = NotBLL.RetrieveNoticiaByID(id);

            var nivelBLL = new NivelBLL();
            List<tblNivel> listaNivel = nivelBLL.RetrieveAll();
            ViewBag.idNivel = new SelectList(listaNivel, "idNivel", "nivelNombre", objNot.idNivel);

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
        public ActionResult DeleteNoticias(int id)
        {
            var notBLL = new NoticiaBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblNoticia noticia = notBLL.RetrieveNoticiaByID(id);

                if (noticia != null)
                {
                    var lvlBLL = new NivelBLL();
                    List<tblNivel> listaNivel = lvlBLL.RetrieveNoticiasNivelByID(id);

                    if (listaNivel.Count() >= 0)
                    {
                        //significa que tiene eventos....
                    }

                    bool banderita = notBLL.Delete(id);

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
                    objJson.mensaje = "La noticia  no se encontró";
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

