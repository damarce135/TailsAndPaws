using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            ProdCategoria = new HashSet<ProdCategorium>();
            Productos = new HashSet<Producto>();
        }

        [Key]
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }

        public virtual ICollection<ProdCategorium> ProdCategoria { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
