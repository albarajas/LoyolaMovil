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
    
    public partial class tblAula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAula()
        {
            this.tblAreas = new HashSet<tblArea>();
            this.tblEventos = new HashSet<tblEvento>();
        }
    
        public int idAula { get; set; }
        public string nombreAula { get; set; }
        public int idTipoAula { get; set; }
        public int idEdificio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArea> tblAreas { get; set; }
        public virtual tblEdificio tblEdificio { get; set; }
        public virtual tblTipoAula tblTipoAula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEvento> tblEventos { get; set; }
    }
}
