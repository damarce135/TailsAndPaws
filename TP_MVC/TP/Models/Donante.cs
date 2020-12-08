using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Donante
    {
        [Key]
        [GenericRequired]
        [Display(Name = "Identificador")]
        public int IdDonante { get; set; }
        public string Nombre { get; set; }

        [Display(Name ="Primer Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44, ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44, ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string Apellido2 { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El teléfono debe ser válido.  Ingrese sólo valores númericos.")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "El teléfono debe ser válido. Ingrese sólo valores númericos.")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo electrónico debe ser válido.")]
        public string Email { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }
    }
}
