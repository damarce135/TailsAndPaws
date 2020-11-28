using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TP.Models
{
    public partial class Donante
    {
        [Key]
        [Required]
        [Display(Name = "Identificador")]
        public int IdDonante { get; set; }
        public string Nombre { get; set; }

        [Display(Name ="Primer Apellido")]
        public string Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }
    }
}
