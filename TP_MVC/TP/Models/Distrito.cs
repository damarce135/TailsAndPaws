using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Adoptantes = new HashSet<Adoptante>();
            Organizacions = new HashSet<Organizacion>();
        }

        [Key]
        public int IdDistrito { get; set; }
        public string NombreDistrito { get; set; }

        public virtual ICollection<Adoptante> Adoptantes { get; set; }
        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
