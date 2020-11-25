using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TP.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Adopcions = new HashSet<Adopcion>();
        }

        [Key]
        [Required]
        [Display(Name ="Identificador")]
        public int IdAnimal { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Raza { get; set; }

        [Required]
        public bool Castrado { get; set; }

        [Required]
        public string Edad { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [Display(Name = "Grupo Sanguíneo")]
        public int IdGsanguineo { get; set; }
        //public IEnumerable<GrupoSanguineo> GrupoSanguineos { get; set; }
        //public GrupoSanguineo GrupoSanguineo { get; set; }

        [Display(Name = "Organización")]
        public int IdOrganizacion { get; set; }
        //public IEnumerable<Organizacion> Organizacions { get; set; }
        //public Organizacion Organizacion { get; set; }

        [Display(Name = "Estado")]
        public bool Habilitado { get; set; }

        [Required]
        public string Especie { get; set; }

        [Required]
        public bool Adoptado { get; set; }

        [ForeignKey("IdGsanguineo")]
        public virtual GrupoSanguineo IdGsanguineoNavigation { get; set; }

        [ForeignKey("IdOrganizacion")]
        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }

        [NotMapped]
        public string Fullname => string.Format("{0} {1} {2}", Raza, Sexo, Nombre);
    }
}
