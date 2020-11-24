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
        [Required]
        [Display(Name ="Identificador")]
        public int IdAdopcion { get; set; }

        [Required]
        [Display(Name = "Animal")]
        public int IdAnimal { get; set; }

        [Required]
        [Display(Name = "Adoptante")]
        public int IdAdoptante { get; set; }

        [Required]
        [Display(Name = "Fecha de Adopción")]
        public DateTime FechaAdopcion { get; set; }

        [Required]
        [Display(Name = "Fecha de Seguimiento")]
        public DateTime? FechaSeguimiento { get; set; }

        [Display(Name = "Estado")]
        public bool Habilitado { get; set; }

        [ForeignKey("IdAdoptante")]
        public virtual Adoptante IdAdoptanteNavigation { get; set; }

        [ForeignKey("IdAnimal")]
        public virtual Animal IdAnimalNavigation { get; set; }
    }
}
