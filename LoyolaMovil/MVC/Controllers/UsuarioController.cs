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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            var usuBLL = new UsuarioBLL();
            List<tblUsuario> listaUsuario = usuBLL.RetrieveAll();

            return View(listaUsuario);

        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(tblUsuario usuario)
        {
            var usuBLL = new UsuarioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    usuBLL.Create(usuario);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuBLL = new UsuarioBLL();
            tblUsuario objUs = usuBLL.RetrieveUsuarioByID(id);

            return View(objUs);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(tblUsuario Usuario)
        {
            var usuBLL = new UsuarioBLL();
            ActionResult Result = null;

            try
            {
                if (ModelState.IsValid)
                {
                    usuBLL.Update(Usuario);
                    Result = RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

            return Result;
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var usuBLL = new UsuarioBLL();
            wmJsonResult objJson = new wmJsonResult();

            try
            {
                tblUsuario Usuario = usuBLL.RetrieveUsuarioByID(id);

                if (Usuario != null)
                {
                    bool banderita = usuBLL.Delete(id);

                    if (banderita == true)
                    {
                        objJson.bandera = true;
                        objJson.mensaje = "El usuario se eliminó correctamente";
                    }
                    else
                    {
                        objJson.bandera = false;
                        objJson.mensaje = "El usuario NO se eliminó correctamente";
                    }

                }
                else
                {
                    objJson.bandera = false;
                    objJson.mensaje = "El usuario no se encontró";
                }
            }
            catch
            {
                objJson.bandera = false;
                objJson.mensaje = "Ocurrio una excepcion al eliminar el usuario";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
    }
}
