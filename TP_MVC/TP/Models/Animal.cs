using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Adopcions = new HashSet<Adopcion>();
        }

        [Key]
        public int IdAnimal { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public bool Castrado { get; set; }
        public string Edad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdGsanguineo { get; set; }
        public int IdOrganizacion { get; set; }
        public bool Habilitado { get; set; }
        public string Especie { get; set; }
        public bool Adoptado { get; set; }

        public virtual GrupoSanguineo IdGsanguineoNavigation { get; set; }
        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }
    }
}
