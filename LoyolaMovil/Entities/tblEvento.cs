//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEvento
    {
        public int idEvento { get; set; }
        public string nombreEvento { get; set; }
        public string descripcionEvento { get; set; }
        public System.DateTime fechaEvento { get; set; }
        public System.DateTime horaInicio { get; set; }
        public System.DateTime horaFinal { get; set; }
        public int idAula { get; set; }
        public int idColaborador { get; set; }
        public int idNivel { get; set; }
    
        public virtual tblAula tblAula { get; set; }
        public virtual tblColaboradore tblColaboradore { get; set; }
        public virtual tblNivel tblNivel { get; set; }
    }
}
