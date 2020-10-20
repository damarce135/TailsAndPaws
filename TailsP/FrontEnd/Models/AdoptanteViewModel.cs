using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class AdoptanteViewModel
    {
        [Display(Name="Identificador")]
        public int idAdoptante { get; set; }

        [Required(ErrorMessage = "Debe digitar el Número de Cédula del Adoptante.")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 9)]
        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre del Adoptante.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar el Primer Apellido del Adoptante.")]
        [Display(Name = "Primer Apellido")]
        public string apellido1 { get; set; }

        [Required(ErrorMessage = "Debe digitar un Segundo Apellido del Adoptante.")]
        [Display(Name = "Segundo Apellido")]
        public string apellido2 { get; set; }

        [Required(ErrorMessage = "Debe digitar el Correo Electrónico del Adoptante.")]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

        [Required(ErrorMessage = "Debe digitar el Número Telefónico del Adoptante.")]
        [Phone]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Debe indicar si el Adoptante está habilitado o no.")]
        [Display(Name = "Estado")]
        public bool habilitado { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Provincia.")]
        [Display(Name = "Provincia")]
        public int idProvincia { get; set; }
        public IEnumerable<provincia> provincias { get; set; }
        public provincia provincia { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Cantón.")]
        [Display(Name = "Cantón")]
        public int idCanton { get; set; }
        public IEnumerable<canton> cantones { get; set; }
        public canton canton { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Distrito.")]
        [Display(Name = "Distrito")]
        public int idDistrito { get; set; }
        public IEnumerable<distrito> distritos { get; set; }
        public distrito distrito { get; set; }

        [Required(ErrorMessage = "Debe digitar el Detalle de la Dirección del Adoptante.")]
        [Display(Name = "Detalle de la Dirección")]
        public string detalleDireccion { get; set; }
    }
}