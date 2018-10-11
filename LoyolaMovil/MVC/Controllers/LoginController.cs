using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entities;

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

        public ActionResult ValidarUsuario(string usuario, string contrasenia)
        {
            var ocBLL = new ColaboradorBLL();
            tblColaboradore objColaborador = ocBLL.ValidarUsuarioContrasenia(usuario, contrasenia);

            if (objColaborador != null)
            {
                //si lo encontro.....
            }

            return View("LoginCompleto", objColaborador);
        }
        
    }
}
