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
    
    public partial class calendario
    {
        public int idCalendario { get; set; }
        public string asunto { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public System.DateTime fechaFinal { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> diaCompleto { get; set; }
        public string temaColor { get; set; }
    }
}