using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Adoptante
    {
        public Adoptante()
        {
            Adopcions = new HashSet<Adopcion>();
        }

        [Key]
        public int IdAdoptante { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
        public int IdDistrito { get; set; }
        public string DetalleDireccion { get; set; }
        public bool Habilitado { get; set; }

        public virtual Canton IdCantonNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }
    }
}
