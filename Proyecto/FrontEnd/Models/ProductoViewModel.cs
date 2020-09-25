using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Key]
        [Display(Name = "Identificador")]
        public int idProducto { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public Nullable<System.DateTime> fechaIngreso { get; set; }

        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        //[Display(Name = "Categoría")]
        //public int idCategoria { get; set; }
        //public IEnumerable<categoria> categorias { get; set; }
        //public categoria categoria { get; set; }

        //[Display(Name = "Proveedor")]
        //public int idProveedor { get; set; }
        //public IEnumerable<proveedor> proveedores { get; set; }
        //public proveedor proveedor { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> habilitado { get; set; }

        
    }
}