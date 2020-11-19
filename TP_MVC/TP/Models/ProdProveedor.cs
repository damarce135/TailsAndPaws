using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class ProdProveedor
    {
        [Key]
        public int IdProdProveedor { get; set; }
        public int IdProducto { get; set; }
        public int IdOrganizacion { get; set; }

        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
