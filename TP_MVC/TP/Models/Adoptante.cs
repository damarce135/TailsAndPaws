using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [Display(Name ="Identificador")]
        public int IdAdoptante { get; set; }

        [Range(1,9)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        public int IdProvincia { get; set; }

        [Required]
        [Display(Name = "Cantón")]
        public int IdCanton { get; set; }

        [Required]
        [Display(Name = "Distrito")]
        public int IdDistrito { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string DetalleDireccion { get; set; }

        [Display(Name = "Preferido")]
        public bool Habilitado { get; set; }

        [ForeignKey("IdCanton")]
        [Display(Name = "Canton")]
        public virtual Canton IdCantonNavigation { get; set; }

        [ForeignKey("IdDistrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }

        [ForeignKey("IdProvincia")]
        [Display(Name = "Provincia")]
        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }

        [NotMapped]
        public string Fullname => string.Format("{0} {1} {2}", Cedula, Nombre, Apellido1);
    }
}
