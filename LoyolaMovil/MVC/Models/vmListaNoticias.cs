using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class vmListaNoticias
    {
        public int idNoticias { get; set; }
        public string noticiasTitulo { get; set; }
        public string noticiasTexto { get; set; }
        public string idNivel { get; set; }
    }
}