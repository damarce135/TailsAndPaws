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

        [Required(ErrorMessage = "Debe digitar el Nombre del Producto.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe digitar la Descripción del Producto.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe digitar el Fecha de Ingreso del Producto.")]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe digitar la Cantidad del Producto.")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "Debe indicar si el Producto está habilitado o no.")]
        [Display(Name = "Estado")]
        public bool habilitado { get; set; }
    }
}