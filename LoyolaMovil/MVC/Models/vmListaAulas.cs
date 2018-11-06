using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class vmListaAulas
    {
        public int idAula { get; set; }
        public string nombreAula { get; set; }
        public string idTipoAula { get; set; }
        public string idEdificio { get; set; }
    }
}