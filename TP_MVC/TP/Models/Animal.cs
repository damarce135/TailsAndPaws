using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        //public IEnumerable<GrupoSanguineo> GrupoSanguineos { get; set; }
        //public GrupoSanguineo GrupoSanguineo { get; set; }
        public int IdOrganizacion { get; set; }
        //public IEnumerable<Organizacion> Organizacions { get; set; }
        //public Organizacion Organizacion { get; set; }
        public bool Habilitado { get; set; }
        public string Especie { get; set; }
        public bool Adoptado { get; set; }

        [ForeignKey("IdGsanguineo")]
        public virtual GrupoSanguineo IdGsanguineoNavigation { get; set; }

        [ForeignKey("IdOrganizacion")]
        public virtual Organizacion IdOrganizacionNavigation { get; set; }
        public virtual ICollection<Adopcion> Adopcions { get; set; }
    }
}
