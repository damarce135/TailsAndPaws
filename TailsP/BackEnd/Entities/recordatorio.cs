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
    
    public partial class recordatorio
    {
        public int idRecordatorio { get; set; }
        public System.DateTime creado { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string urgencia { get; set; }
        public Nullable<int> alertaEstado { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<bool> habilitado { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}