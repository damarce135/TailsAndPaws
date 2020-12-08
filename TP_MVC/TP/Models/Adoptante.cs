using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Adoptante : IValidatableObject
    {
        public Adoptante()
        {
            Adopcions = new HashSet<Adopcion>();
        }

        [Key]
        [Display(Name = "Identificador")]
        [GenericRequired]
        public int IdAdoptante { get; set; }

        [MinLength(9,ErrorMessage = "La cédula debe tener 9 dígitos exactos.")]
        [MaxLength(9,ErrorMessage = "La cédula debe tener 9 dígitos exactos.")]
        [GenericRequired]
        [Display(Name = "Cédula")]
        public string? Cedula { get; set; }

        [GenericRequired]
        public string? Nombre { get; set; }

        [GenericRequired]
        [Display(Name = "Primer Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44, ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string? Apellido1 { get; set; }

        [GenericRequired]
        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44, ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string? Apellido2 { get; set; }

        [GenericRequired]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo electrónico debe ser válido.")]
        public string? Email { get; set; }

        [GenericRequired]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El teléfono debe ser válido.  Ingrese sólo valores númericos.")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "El teléfono debe ser válido. Ingrese sólo valores númericos.")]
        public string? Telefono { get; set; }

        [GenericRequired]
        [Display(Name = "Provincia")]
        public int? IdProvincia { get; set; }

        //[Required]
        //[Display(Name = "Cantón")]
        //public int IdCanton { get; set; }

        //[Required]
        //[Display(Name = "Distrito")]
        //public int IdDistrito { get; set; }

        [GenericRequired]
        [Display(Name = "Dirección")]
        public string? DetalleDireccion { get; set; }

        [Display(Name = "Preferido")]
        public bool Habilitado { get; set; }

        //[ForeignKey("IdCanton")]
        //[Display(Name = "Canton")]
        //public virtual Canton IdCantonNavigation { get; set; }

        //[ForeignKey("IdDistrito")]
        //public virtual Distrito IdDistritoNavigation { get; set; }

        [ForeignKey("IdProvincia")]
        [Display(Name = "Provincia")]
        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }

        [NotMapped]
        public string Fullname => string.Format("{0} {1} {2}", Cedula, Nombre, Apellido1);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Adopcions.Count > 0)
            {
                yield return new ValidationResult(
                        $"El adoptante tiene una adopción existente. Favor borrar el registro en adopción para poder eliminar el adoptante.",
                        new[] { nameof(IdAdoptante) });
            }
        }
    }
}
