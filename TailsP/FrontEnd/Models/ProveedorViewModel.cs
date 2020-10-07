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

        [Display(Name = "Dirección")]
        public int idDireccion { get; set; }
        public IEnumerable<direccion> direcciones { get; set; }
        public direccion direccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Estado")]
        public bool habilitado { get; set; }
    }
}