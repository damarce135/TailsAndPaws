using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Adoptantes = new HashSet<Adoptante>();
            Organizacions = new HashSet<Organizacion>();
        }

        [Key]
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Adoptante> Adoptantes { get; set; }
        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
