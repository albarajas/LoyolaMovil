using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class vmListaEventos
    {
        public int idEvento { get; set; }

        public string nombreEvento { get; set; }
        public string descripcionEvento { get; set; }
        public System.DateTime fechaEvento { get; set; }
        public string horaInicio { get; set; }
        public string horaFinal { get; set; }
        public string idAula { get; set; }
        public string idColaborador { get; set; }
        public string idNivel { get; set; }

    }
}