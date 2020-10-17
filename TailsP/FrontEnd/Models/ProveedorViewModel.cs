using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProveedorViewModel
    {
        [Display(Name ="Identificador")]
        public int idProveedor { get; set; }

        [Display(Name = "Nombre")]
        public string nombreProveedor { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Estado")]
        public bool habilitado { get; set; }

        [Display(Name = "Provincia")]
        public int idProvincia { get; set; }
        public IEnumerable<provincia> provincias{ get; set; }
        public provincia provincia { get; set; }

        [Display(Name = "Cantón")]
        public int idCanton { get; set; }
        public IEnumerable<canton> cantones { get; set; }
        public canton canton { get; set; }

        [Display(Name = "Distrito")]
        public int idDistrito { get; set; }
        public IEnumerable<distrito> distritos{ get; set; }
        public distrito distrito { get; set; }

        [Display(Name = "Detalle de la Dirección")]
        public string detalleDireccion { get; set; }
    }
}