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
        [Key]
        [Display(Name = "Identificador")]
        public int idAnimal { get; set; }

        [Display(Name ="Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        [Display(Name = "Raza")]
        public string raza { get; set; }

        [Display(Name = "Castrado")]
        public string castrado { get; set; }

        [Display(Name = "Edad")]
        public string edad { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public Nullable<System.DateTime> fechaIngreso { get; set; }

        [Display(Name = "Grupo Sanguíneo")]
        public int idGSanguineo { get; set; }
        public IEnumerable<grupoSanguineo> grupoSanguineos { get; set; }
        public grupoSanguineo grupoSanguineo { get; set; }

        [Display(Name = "Organización")]
        public int idOrganizacion { get; set; }
        public IEnumerable<organizacion> organizaciones{ get; set; }
        public organizacion organizacion { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> habilitado { get; set; }
    }
}