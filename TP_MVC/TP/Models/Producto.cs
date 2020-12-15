using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ProdCategoria = new HashSet<ProdCategorium>();
            ProdProveedors = new HashSet<ProdProveedor>();
        }

        [Key]
        [Display(Name ="Identificador")]
        [GenericRequired]
        public int IdProducto { get; set; }

        [GenericRequired]
        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [GenericRequired]
        [Display(Name ="Fecha de Ingreso")]
        public DateTime? FechaIngreso { get; set; }

        [GenericRequired]
        [RegularExpression(@"^[1-9]\d{0,2}$", ErrorMessage = "Cantidad inválida, debe ser un número positivo.")]
        public int? Cantidad { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }

        [GenericRequired]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        [Display(Name = "Categoría")]
        public virtual Categorium IdCategoriaNavigation { get; set; }

        public virtual ICollection<ProdCategorium> ProdCategoria { get; set; }
        public virtual ICollection<ProdProveedor> ProdProveedors { get; set; }
    }
}
