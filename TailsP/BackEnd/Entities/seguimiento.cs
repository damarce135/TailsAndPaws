//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class seguimiento
    {
        public int idSeguimiento { get; set; }
        public int idAnimal { get; set; }
        public int idAdoptante { get; set; }
        public string estado { get; set; }
        public Nullable<bool> habilitado { get; set; }
    
        public virtual adoptante adoptante { get; set; }
        public virtual animal animal { get; set; }
    }
}
