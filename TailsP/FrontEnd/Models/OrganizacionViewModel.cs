using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class OrganizacionViewModel
    {
        [Display(Name ="Identificador")]
        public int idOrganizacion { get; set; }

        [Required(ErrorMessage = "Debe digitar el Tipo de Organización.")]
        [Display(Name = "Tipo de Organización")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Debe digitar el Nombre de la Organización.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar el Número Telefónico de la Organización.")]
        [Phone]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Debe digitar el Correo Electrónico de la Organización.")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [Required(ErrorMessage = "Debe digitar la Descripción de la Organización.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe indicar si la Organización está habilitada o no.")]
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

        [Required(ErrorMessage = "Debe digitar el Detalle de la Dirección de la Organización.")]
        [Display(Name = "Detalle de la Dirección")]
        public string detalleDireccion { get; set; }
    }
}