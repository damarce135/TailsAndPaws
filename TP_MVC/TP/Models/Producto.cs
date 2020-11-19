using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<ProdCategorium> ProdCategoria { get; set; }
        public virtual ICollection<ProdProveedor> ProdProveedors { get; set; }
    }
}
