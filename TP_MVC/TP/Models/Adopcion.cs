using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Adopcion : IValidatableObject
    {
        [Key]
        [GenericRequired]
        [Display(Name ="Identificador")]
        public int IdAdopcion { get; set; }

        [GenericRequired]
        [Display(Name = "Animal")]
        public int IdAnimal { get; set; }

        [GenericRequired]
        [Display(Name = "Adoptante")]
        public int IdAdoptante { get; set; }

        [GenericRequired]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Adopción")]
        public DateTime? FechaAdopcion { get; set; }

        [GenericRequired]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Seguimiento")]
        public DateTime? FechaSeguimiento { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }

        [NotMapped]
        public ICollection<SelectListItem> Adoptantes { set; get; }

        [ForeignKey("IdAdoptante")]
        [Display(Name = "Adoptante")]
        public virtual Adoptante IdAdoptanteNavigation { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Animales { set; get; }

        [ForeignKey("IdAnimal")]
        [Display(Name = "Animalito")]
        public virtual Animal IdAnimalNavigation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaAdopcion > FechaSeguimiento)
            {
                yield return new ValidationResult(
                    $"La fecha de seguimiento debe ser después de la fecha de adopción.",
                    new[] { nameof(FechaSeguimiento) });
            }
        }

    }
}
