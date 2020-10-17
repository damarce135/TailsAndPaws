using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class AdopcionViewModel
    {
        [Display(Name = "Identificador")]
        public int idAdopcion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un animal.")]
        [Display(Name ="Animal")]
        public int idAnimal { get; set; }
        public IEnumerable<animal> animales { get; set; }
        public animal animal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un adoptante.")]
        [Display(Name = "Adoptante")]
        public int idAdoptante { get; set; }
        public IEnumerable<adoptante> adoptantes{ get; set; }
        public adoptante adoptante { get; set; }

        [Required(ErrorMessage = "Debe digitar una fecha de adopción (DD-MM-AAAA).")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de la Adopción")]
        public System.DateTime fechaAdopcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Seguimiento")]
        public System.DateTime fechaSeguimiento { get; set; }

        [Display(Name = "Estado")]
        public bool habilitado { get; set; }   
    }
}