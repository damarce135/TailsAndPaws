using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class AnimalViewModel
    {
        [Display(Name = "Identificador")]
        public int idAnimal { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del Animal.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar el Sexo del Animal. H: Hembra, M: Macho")]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        public enum Sexo
        {
            Hembra,
            Macho
        }

        [Required(ErrorMessage = "Debe digitar la Raza del Animal.")]
        [Display(Name = "Raza")]
        public string raza { get; set; }

        [Required(ErrorMessage = "Debe indicar si el Animal está castrado.")]
        [Display(Name = "Castrado")]
        public bool castrado { get; set; }

        [Required(ErrorMessage = "Debe digitar la Edad del Animal.")]
        [Display(Name = "Edad")]
        public string edad { get; set; }

        [Required(ErrorMessage = "Debe digitar la Fecha de Ingreso del Animal.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Ingreso")]
        public System.DateTime fechaIngreso { get; set; }

        [Display(Name = "Grupo Sanguíneo")]
        public int idGSanguineo { get; set; }
        public IEnumerable<grupoSanguineo> grupoSanguineos { get; set; }
        public grupoSanguineo grupoSanguineo { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la Organización del Animal.")]
        [Display(Name = "Casa Cuna")]
        public int idOrganizacion { get; set; }
        public IEnumerable<organizacion> organizaciones { get; set; }
        public organizacion organizacion { get; set; }

        [Required(ErrorMessage ="Debe digitar una Especie")]
        [Display(Name ="Especie")]
        public string especie { get; set; }

        [Required(ErrorMessage ="Debe digitar si el Animal está Adoptado (Sí) o no (No).")]
        [Display(Name="Adoptado")]
        public bool adoptado { get; set; }

        [Required(ErrorMessage = "Debe indicar si el Animal está habilitado o no.")]
        [Display(Name = "Estado")]
        public bool habilitado { get; set; }
    }
}