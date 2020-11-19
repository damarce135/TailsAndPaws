using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Calendario
    {
        [Key]
        public int IdCalendario { get; set; }
        public string Asunto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Descripcion { get; set; }
        public bool? DiaCompleto { get; set; }
        public string TemaColor { get; set; }
    }
}
