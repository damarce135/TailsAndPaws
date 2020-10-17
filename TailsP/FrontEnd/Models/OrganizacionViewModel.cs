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

        [Required(ErrorMessage = "Debe digitar un Tipo de Organización: Casa Cuna, Proveedor, Veterinaria.")]
        [Display(Name = "Tipo de Organización")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "Debe digitar un Nombre.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar un Teléfono.")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Debe digitar un Correo Electrónico.")]
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [Required(ErrorMessage = "Debe digitar una Descripción.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

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

        [Required(ErrorMessage = "Debe digitar el Detalle de la Dirección.")]
        [Display(Name = "Detalle de la Dirección")]
        public string detalleDireccion { get; set; }
    }
}