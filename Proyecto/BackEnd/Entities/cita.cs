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
    
    public partial class cita
    {
        public int idCita { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public string motivo { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<bool> habilitado { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}