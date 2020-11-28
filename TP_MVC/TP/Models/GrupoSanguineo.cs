using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class GrupoSanguineo
    {
       
        [Key]
        public int IdGsanguineo { get; set; }
        public string NombreGsanguineo { get; set; }

    }
}
