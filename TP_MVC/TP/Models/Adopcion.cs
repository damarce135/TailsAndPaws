using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TP.Models
{
    public partial class Adopcion
    {
        [Key]
        public int IdAdopcion { get; set; }
        public int IdAnimal { get; set; }
        public int IdAdoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public DateTime? FechaSeguimiento { get; set; }
        public bool Habilitado { get; set; }

        [ForeignKey("IdAdoptante")]
        public virtual Adoptante IdAdoptanteNavigation { get; set; }

        [ForeignKey("IdAnimal")]
        public virtual Animal IdAnimalNavigation { get; set; }
    }
}
