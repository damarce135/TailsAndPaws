using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Display(Name="Identificador")]
        public int idProducto { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaIngreso { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> cantidad { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> habilitado { get; set; }
    }
}