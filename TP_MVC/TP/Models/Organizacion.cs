using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Animals = new HashSet<Animal>();
            ProdProveedors = new HashSet<ProdProveedor>();
        }

        [Key]
        public int IdOrganizacion { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }
        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
        public int IdDistrito { get; set; }
        public string DetalleDireccion { get; set; }
        public bool Habilitado { get; set; }

        public virtual Canton IdCantonNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<ProdProveedor> ProdProveedors { get; set; }
    }
}
