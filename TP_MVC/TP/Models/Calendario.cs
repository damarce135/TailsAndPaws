using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Calendario : IValidatableObject
    {
        [Key]
        [Display(Name = "Identificador")]
        public int IdCalendario { get; set; }

        [GenericRequired]
        [Display(Name = "Asunto")]
        public string? Asunto { get; set; }

        [GenericRequired]
        [Display(Name = "Inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Final")]
        public DateTime FechaFinal { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [GenericRequired]
        [Display(Name = "Evento de todo el día")]
        public bool DiaCompleto { get; set; }

        [GenericRequired]
        [Display(Name = "Color")]
        public string? TemaColor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaInicio > FechaFinal)
            {
                yield return new ValidationResult(
                    $"La fecha final debe ser después de la fecha de incio.",
                    new[] { nameof(FechaFinal) });
            }
        }
    }
}
