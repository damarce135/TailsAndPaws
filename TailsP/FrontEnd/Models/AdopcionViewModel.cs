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

        [Required(ErrorMessage = "Debe seleccionar un Animal.")]
        [Display(Name ="Animal")]
        public int idAnimal { get; set; }
        public IEnumerable<animal> animales { get; set; }
        public animal animal { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Adoptante.")]
        [Display(Name = "Adoptante")]
        public int idAdoptante { get; set; }
        public IEnumerable<adoptante> adoptantes{ get; set; }
        public adoptante adoptante { get; set; }

        [Required(ErrorMessage = "Debe digitar la Fecha de Adopción.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de la Adopción")]
        public System.DateTime fechaAdopcion { get; set; }

        [Required(ErrorMessage = "Debe digitar la Fecha de Seguimiento.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Seguimiento")]
        public System.DateTime fechaSeguimiento { get; set; }

        [Required(ErrorMessage = "Debe indicar si la Adopción está habilitada o no.")]
        [Display(Name = "Estado")]
        public bool habilitado { get; set; }   
    }
}