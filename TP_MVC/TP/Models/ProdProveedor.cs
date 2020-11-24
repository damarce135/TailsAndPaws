using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TP.Models
{
    public partial class ProdProveedor
    {
        [Key]
        public int IdProdProveedor { get; set; }
        public int IdProducto { get; set; }
        public int IdOrganizacion { get; set; }

        [ForeignKey("IdOrganizacion")]
        public virtual Organizacion IdOrganizacionNavigation { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
