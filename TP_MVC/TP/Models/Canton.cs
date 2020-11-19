using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Canton
    {
        public Canton()
        {
            Adoptantes = new HashSet<Adoptante>();
            Organizacions = new HashSet<Organizacion>();
        }

        [Key]
        public int IdCanton { get; set; }
        public string NombreCanton { get; set; }

        public virtual ICollection<Adoptante> Adoptantes { get; set; }
        public virtual ICollection<Organizacion> Organizacions { get; set; }
    }
}
