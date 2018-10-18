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
    public class LoginController : Controller
    {
        /// <summary>
        /// Metodo que genera la vista de login de usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        public JsonResult ValidarUsuario(string correo_p, string password_p)
        {
            var ocBLL = new ColaboradorBLL();
            tblColaboradore objColaborador = ocBLL.ValidarUsuarioContrasenia(correo_p, password_p);
            wmJsonResult objJson = new wmJsonResult();
                  
            if (objColaborador != null)
            {
                objJson.bandera = true;
                objJson.mensaje = objColaborador.nombreColaborador;
            }
            else
            {
                objJson.bandera = false;
                objJson.mensaje = "No se encontró usuario";
            }

            return Json(objJson, JsonRequestBehavior.AllowGet);
        }
        
    }
}
