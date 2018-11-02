using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class vmListaAreas
    {
        public int idArea { get; set; }
        public string nombreArea { get; set; }
        public string horaInicio { get; set; }
        public string horaFinal { get; set; }
        public string idColaborador { get; set; }
        public string idAula { get; set; }
    }
}