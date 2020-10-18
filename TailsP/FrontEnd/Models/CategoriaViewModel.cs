using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CategoriaViewModel
    {
        [Key]
        [Display(Name ="Identificador")]
        public int idCategoria { get; set; }

        [Required(ErrorMessage = "Debe digitar un Nombre para la Categoría.")]
        [Display(Name ="Categoría")]
        public string nombreCategoria { get; set; }
    }
}