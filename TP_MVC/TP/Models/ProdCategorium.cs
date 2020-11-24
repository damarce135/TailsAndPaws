using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TP.Models
{
    public partial class ProdCategorium
    {
        [Key]
        public int IdProdCategoria { get; set; }
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categorium IdCategoriaNavigation { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
