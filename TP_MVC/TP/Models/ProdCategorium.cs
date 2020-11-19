using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class ProdCategorium
    {
        [Key]
        public int IdProdCategoria { get; set; }
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
