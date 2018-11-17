using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class vmListaColaborador
    {
        public int idColaborador { get; set; }
        public string nombreColaborador { get; set; }
        public string telefonoColaborador { get; set; }
        public string correoColaborador { get; set; }
        public string horarioInicio { get; set; }
        public string horaFin { get; set; }
        public string contraseniaColaborador { get; set; }
    }
}