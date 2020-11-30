using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Adoptante
    {
        public Adoptante()
        {
            Adopcions = new HashSet<Adopcion>();
        }

        [Key]
        [GenericRequired]
        [Display(Name ="Identificador")]
        public int IdAdoptante { get; set; }

        [MinLength(9)]
        [MaxLength(9)]
        [GenericRequired]
        [Display(Name = "Cédula")]
        public string? Cedula { get; set; }

        [GenericRequired]
        public string? Nombre { get; set; }

        [GenericRequired]
        [Display(Name = "Primer Apellido")]
        public string? Apellido1 { get; set; }

        [GenericRequired]
        [Display(Name = "Segundo Apellido")]
        public string? Apellido2 { get; set; }

        [GenericRequired]
        public string? Email { get; set; }

        [GenericRequired]
        [Display(Name = "Teléfono")]
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
        public bool? Habilitado { get; set; }

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
    }
}
