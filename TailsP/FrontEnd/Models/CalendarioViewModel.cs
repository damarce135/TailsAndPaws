using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CalendarioViewModel
    {
        public int idCalendario { get; set; }
        public string asunto { get; set; }
        public System.DateTime? fechaInicio { get; set; }
        public System.DateTime fechaFinal { get; set; }
        public string descripcion { get; set; }
        public bool diaCompleto { get; set; }
        public string temaColor { get; set; }
    }
}