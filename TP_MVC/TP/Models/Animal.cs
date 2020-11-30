using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

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
        [GenericRequired]
        [Display(Name ="Identificador")]
        public int IdAnimal { get; set; }

        [GenericRequired]
        public string? Nombre { get; set; }

        [GenericRequired]
        public string? Sexo { get; set; }

        [GenericRequired]
        [Display(Name = "Tamaño")]
        public string? Tamano { get; set; }

        [GenericRequired]
        [Display(Name = "Características")]
        public string? Caracteristicas { get; set; }

        public bool Castrado { get; set; }

        [GenericRequired]
        public string? Edad { get; set; }

        [GenericRequired]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }

        //[Required]
        //[Display(Name = "Grupo Sanguíneo")]
        //public int IdGsanguineo { get; set; }
        //public IEnumerable<GrupoSanguineo> GrupoSanguineos { get; set; }
        //public GrupoSanguineo GrupoSanguineo { get; set; }

        [Display(Name = "Casa Cuna")]
        public int? IdOrganizacion { get; set; }
        //public IEnumerable<Organizacion> Organizacions { get; set; }
        //public Organizacion Organizacion { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }

        [GenericRequired]
        public string Especie { get; set; }

        public bool Adoptado { get; set; }

        //[ForeignKey("IdGsanguineo")]
        //[Display(Name = "Características")]
        //public virtual GrupoSanguineo IdGsanguineoNavigation { get; set; }

        [ForeignKey("IdOrganizacion")]
        [Display(Name = "Casa cuna")]
        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }

        [NotMapped]
        public string Fullname => string.Format("{0} {1} {2}", Tamano, Sexo, Nombre);
    }
}
