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

        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string apellido2 { get; set; }

        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Dirección")]
        public int idDireccion { get; set; }
        public IEnumerable<direccion> direcciones { get; set; }
        public direccion direccion { get; set; }

        [Display(Name = "Estado")]
        public bool habilitado { get; set; }
    }
}